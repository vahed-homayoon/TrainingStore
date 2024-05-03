using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Teachers.Config;

internal sealed class TeacherConfig : IEntityTypeConfiguration<Teacher>
{
	public void Configure(EntityTypeBuilder<Teacher> builder)
	{
		builder
			.Property(teacher => teacher.Address)
			.HasMaxLength(200);
	}
}