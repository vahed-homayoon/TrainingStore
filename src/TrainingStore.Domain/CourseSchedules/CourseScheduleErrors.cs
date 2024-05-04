using Shared.Results;

namespace TrainingStore.Domain.CourseSchedules;

public static class CourseScheduleErrors
{
	public static readonly Error DuplicateName = new(
		"CourseSchedule.DuplicateName",
		"1111111111");

	public static readonly Error NotFound = new(
		"CourseSchedule.NotFound",
		"2222222222");
}