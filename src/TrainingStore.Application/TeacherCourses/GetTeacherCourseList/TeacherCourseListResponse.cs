using TrainingStore.Domain.TeacherCourses;

namespace TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

public sealed class TeacherCourseListResponse
{
	public int Id { get; init; }
	public string? CreatedBy { get; init; }
	public List<CourseSchedule> CourseSchedules { get; set; }
	public DateTime? CreatedDate { get; init; }
	public string? UpdatedBy { get; init; }
	public DateTime? UpdatedDate { get; init; }
}