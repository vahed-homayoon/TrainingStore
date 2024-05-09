using Shared.Entities;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Domain.TeacherCourses;

public sealed class TeacherCourse : BaseEntity, IAuditable
{
	private TeacherCourse() { }

	private TeacherCourse(
		int courseId,
		int teacherId,
		DateTime startDate,
		DateTime endDate,
		List<CourseSchedule> courseSchedules)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		_courseSchedules = courseSchedules;
	}

	public DateTime StartDate { get; private set; }

	public DateTime EndDate { get; private set; }

	private List<CourseSchedule> _courseSchedules = new();

	public IReadOnlyCollection<CourseSchedule> CourseSchedules => _courseSchedules.AsReadOnly();

	public int CourseId { get; private set; }

	public Course Course { get; private set; }

	public int TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static TeacherCourse Create(int courseId, int teacherId, DateTime startDate, DateTime endDate, List<CourseSchedule> courseSchedules)
	{
		var teacherCourse = new TeacherCourse(courseId, teacherId, startDate, endDate, courseSchedules);

		return teacherCourse;
	}

	public void Edit(int courseId, int teacherId, DateTime startDate, DateTime endDate, List<CourseSchedule> courseSchedules)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		_courseSchedules = courseSchedules;
	}
}