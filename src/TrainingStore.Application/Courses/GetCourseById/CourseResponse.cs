namespace TrainingStore.Application.Courses.GetCourseById;

public sealed record CourseResponse(
	Guid Id,
	string Name,
	string Description);