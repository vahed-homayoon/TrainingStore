using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Session;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class SessionConfiguration : IEntityTypeConfiguration<Session>
{
    public void Configure(EntityTypeBuilder<Session> builder)
    {
        builder.ToTable("Sessions");

		builder.HasKey(m => m.Id);

		builder
			.Property(b => b.StartDate)
			.IsRequired();
	}
}