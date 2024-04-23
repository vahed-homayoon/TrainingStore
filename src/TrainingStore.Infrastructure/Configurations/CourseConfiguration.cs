using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Configurations;

internal sealed class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.ToTable("Courses");

		builder.HasKey(m => m.Id);

		builder
			.Property(b => b.Name)
			.HasMaxLength(50)
			.IsRequired();

		builder
			.Property(b => b.Description)
			.HasMaxLength(200)
			.IsRequired();
	}
}