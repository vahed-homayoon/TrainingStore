using Shared.Entities;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Domain.TeacherCourses;

public sealed class TeacherCourse : BaseEntity, IAuditable
{
	private TeacherCourse() 
	{ 
	}

	private TeacherCourse(
		Guid id,
		Guid courseId,
		Guid teacherId,
		DateTime startDate,
		DateTime endDate,
		List<CourseSchedule> courseSchedules) :
			base(id)
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

	public Guid CourseId { get; private set; }

	public Course Course { get; private set; }

	public Guid TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static TeacherCourse Create(Guid courseId, Guid teacherId, DateTime startDate, DateTime endDate, List<CourseSchedule> courseSchedules)
	{
		var teacherCourse = new TeacherCourse(Guid.NewGuid(), courseId, teacherId, startDate, endDate, courseSchedules);

		return teacherCourse;
	}

	public void Edit(Guid courseId, Guid teacherId, DateTime startDate, DateTime endDate, List<CourseSchedule> courseSchedules)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		_courseSchedules = courseSchedules;
	}
}