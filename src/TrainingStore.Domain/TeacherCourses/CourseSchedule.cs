namespace TrainingStore.Domain.TeacherCourses;

public sealed record CourseSchedule(
	DayOfWeek Day,
	TimeSpan FromHour,
	TimeSpan ToHour);