using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Courses.Config;

internal sealed class CourseConfig : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		builder.ToTable("Courses");

		builder.HasKey(course => course.Id);

		builder
			.Property(course => course.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(course => course.Description)
			.HasMaxLength(200)
			.IsRequired();
	}
}