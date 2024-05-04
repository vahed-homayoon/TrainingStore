namespace TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

public sealed record TeacherCourseListResponse(
	int Id,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);