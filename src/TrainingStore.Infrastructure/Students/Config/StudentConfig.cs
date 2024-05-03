using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Students;

namespace TrainingStore.Infrastructure.Students.Config;

internal sealed class StudentConfig : IEntityTypeConfiguration<Student>
{
	public void Configure(EntityTypeBuilder<Student> builder)
	{
		builder
			.Property(student => student.BirthDate)
			.IsRequired();
	}
}