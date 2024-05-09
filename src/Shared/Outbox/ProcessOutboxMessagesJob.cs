using System.Data;
using Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Quartz;
using Shared.Data;
using Shared.DomainEvent;

namespace Shared.Outbox;

[DisallowConcurrentExecution]
internal sealed class ProcessOutboxMessagesJob : IJob
{
	private static readonly JsonSerializerSettings JsonSerializerSettings = new()
	{
		TypeNameHandling = TypeNameHandling.All
	};

	private readonly ISqlConnectionFactory _sqlConnectionFactory;
	private readonly IPublisher _publisher;
	private readonly OutboxOptions _outboxOptions;
	private readonly ILogger<ProcessOutboxMessagesJob> _logger;

	public ProcessOutboxMessagesJob(
		ISqlConnectionFactory sqlConnectionFactory,
		IPublisher publisher,
		IOptions<OutboxOptions> outboxOptions,
		ILogger<ProcessOutboxMessagesJob> logger)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
		_publisher = publisher;
		_logger = logger;
		_outboxOptions = outboxOptions.Value;
	}

	public async Task Execute(IJobExecutionContext context)
	{
		_logger.LogInformation("Beginning to process outbox messages");

		using IDbConnection connection = _sqlConnectionFactory.CreateConnection();
		using IDbTransaction transaction = connection.BeginTransaction();

		IReadOnlyList<OutboxMessageResponse> outboxMessages = await GetOutboxMessagesAsync(connection, transaction);

		foreach (OutboxMessageResponse outboxMessage in outboxMessages)
		{
			Exception? exception = null;

			try
			{
				IDomainEvent domainEvent = JsonConvert.DeserializeObject<IDomainEvent>(
					outboxMessage.Content,
					JsonSerializerSettings)!;

				await _publisher.Publish(domainEvent, context.CancellationToken);
			}
			catch (Exception caughtException)
			{
				_logger.LogError(
					caughtException,
					"Exception while processing outbox message {MessageId}",
					outboxMessage.Id);

				exception = caughtException;
			}

			await UpdateOutboxMessageAsync(connection, transaction, outboxMessage, exception);
		}

		transaction.Commit();

		_logger.LogInformation("Completed processing outbox messages");
	}

	private async Task<IReadOnlyList<OutboxMessageResponse>> GetOutboxMessagesAsync(
		IDbConnection connection,
		IDbTransaction transaction)
	{
		//LIMIT { _outboxOptions.BatchSize}
		string sql = $"""
                      SELECT id, content
                      FROM OutboxMessages
                      WHERE ProcessedOnUtc IS NULL
                      ORDER BY OccurredOnUtc
                      """;

		IEnumerable<OutboxMessageResponse> outboxMessages = await connection.QueryAsync<OutboxMessageResponse>(
			sql,
			transaction: transaction);

		return outboxMessages.ToList();
	}

	private async Task UpdateOutboxMessageAsync(
		IDbConnection connection,
		IDbTransaction transaction,
		OutboxMessageResponse outboxMessage,
		Exception? exception)
	{
		const string sql = @"
            UPDATE OutboxMessages
            SET processedOnUtc = @ProcessedOnUtc,
                error = @Error
            WHERE id = @Id";

		await connection.ExecuteAsync(
			sql,
			new
			{
				outboxMessage.Id,
				ProcessedOnUtc = DateTime.Now,
				Error = exception?.ToString()
			},
			transaction: transaction);
	}

	internal sealed record OutboxMessageResponse(Guid Id, string Content);
}
