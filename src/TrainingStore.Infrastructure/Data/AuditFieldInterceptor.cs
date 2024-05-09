using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Newtonsoft.Json;
using Shared.DomainEvent;
using Shared.Entities;
using Shared.Outbox;

namespace TrainingStore.Infrastructure.Data;

public class AuditFieldInterceptor : SaveChangesInterceptor
{
	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		SetShadowProperties(eventData);

		AddDomainEventsAsOutboxMessages(eventData);

		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		SetShadowProperties(eventData);

		AddDomainEventsAsOutboxMessages(eventData);

		return base.SavingChanges(eventData, result);
	}

	private static void SetShadowProperties(DbContextEventData eventData)
	{
		DateTime now = DateTime.Now;

		var entries = eventData
			.Context
			.ChangeTracker
			.Entries()
			.Where(m => !m.Metadata.IsOwned());

		//foreach (var entry in entries)
		//{
		//	if (entry.State == EntityState.Added)
		//	{
		//		entry.Property("CreatedBy").CurrentValue = "";
		//		entry.Property("CreatedDate").CurrentValue = now;
		//	}
		//	else if (entry.State == EntityState.Modified)
		//	{
		//		entry.Property("UpdatedBy").CurrentValue = "";
		//		entry.Property("UpdatedDate").CurrentValue = now;
		//	}
		//}
	}

	private void AddDomainEventsAsOutboxMessages(DbContextEventData eventData)
	{
		var outboxMessages = eventData
			.Context
			.ChangeTracker
			.Entries<BaseEntity>()
			.Select(entry => entry.Entity)
			.SelectMany(entity =>
			{
				IReadOnlyList<IDomainEvent> domainEvents = entity.GetDomainEvents();

				entity.ClearDomainEvents();

				return domainEvents;
			})
			.Select(domainEvent => new OutboxMessage(
				Guid.NewGuid(),
				DateTime.Now,
				domainEvent.GetType().Name,
				JsonConvert.SerializeObject(domainEvent, JsonSerializerSettings)))
			.ToList();

		eventData.Context.AddRange(outboxMessages);
	}

	private static readonly JsonSerializerSettings JsonSerializerSettings = new()
	{
		TypeNameHandling = TypeNameHandling.All
	};
}