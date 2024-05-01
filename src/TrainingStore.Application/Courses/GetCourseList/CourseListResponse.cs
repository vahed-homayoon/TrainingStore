namespace TrainingStore.Application.Courses.GetCourseList;

public sealed record CourseListResponse(
	int Id,
	string Name,
	string Description,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);