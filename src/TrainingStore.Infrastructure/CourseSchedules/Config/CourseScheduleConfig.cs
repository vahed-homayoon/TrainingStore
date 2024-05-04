using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrainingStore.Domain.CourseSchedules;

namespace TrainingStore.Infrastructure.CourseSchedules.Config;

internal sealed class CourseScheduleConfig : IEntityTypeConfiguration<CourseSchedule>
{
	public void Configure(EntityTypeBuilder<CourseSchedule> builder)
	{
		builder.ToTable("CourseSchedules");

		builder.HasKey(courseSchedule => courseSchedule.Id);

		builder
			.Property(courseSchedule => courseSchedule.StartDate)
			.IsRequired();

		builder
			.Property(courseSchedule => courseSchedule.EndDate)
			.IsRequired();

		builder
			.Property(courseSchedule => courseSchedule.FromHour)
			.IsRequired();

		builder
			.Property(courseSchedule => courseSchedule.ToHour)
			.IsRequired();
	}
}