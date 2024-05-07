namespace TrainingStore.Application.Courses.GetCourseById;

public sealed record CourseResponse(
	int Id,
	string Name,
	string Description);