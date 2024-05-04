using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using TrainingStore.Domain.TeacherCourses;

namespace TrainingStore.Infrastructure.TeacherCourses.Config;

internal sealed class TeacherCourseConfig : IEntityTypeConfiguration<TeacherCourse>
{
	public void Configure(EntityTypeBuilder<TeacherCourse> builder)
	{
		builder.ToTable("TeacherCourses");

		builder.HasKey(cs => cs.Id);

		builder
			.Property(cs => cs.CourseId)
			.IsRequired();

		builder
			.Property(cs => cs.TeacherId)
			.IsRequired();

		builder
			.Property(cs => cs.StartDate)
			.IsRequired();

		builder
			.Property(cs => cs.EndDate)
			.IsRequired();

		builder
			.Property(cs => cs.FromHour)
			.IsRequired();

		builder
			.Property(cs => cs.ToHour)
			.IsRequired();
	}
}