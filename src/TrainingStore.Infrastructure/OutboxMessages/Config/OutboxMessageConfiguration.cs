using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Outbox;

namespace TrainingStore.Infrastructure.OutboxMessages.Config;

internal sealed class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessage>
{
	public void Configure(EntityTypeBuilder<OutboxMessage> builder)
	{
		builder.ToTable("OutboxMessages");

		builder.HasKey(outboxMessage => outboxMessage.Id);

		builder.Property(outboxMessage => outboxMessage.Content);
	}
}
