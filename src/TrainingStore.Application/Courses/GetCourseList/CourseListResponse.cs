namespace TrainingStore.Application.Courses.GetCourseList;

public sealed record CourseListResponse(int Id, string Name, string Description, string? CreateBy, DateTime? CreateDate, string? UpdateBy, DateTime? UpdateDate);