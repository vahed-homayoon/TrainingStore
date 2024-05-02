namespace TrainingStore.Application.Courses.GetCourseList;

public sealed record CourseListResponse(
	int Id,
	string Name,
	string Description,
	bool IsActive,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);