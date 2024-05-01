using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder
			.Property(b => b.Address)
			.HasMaxLength(20)
			.IsRequired();
	}
}