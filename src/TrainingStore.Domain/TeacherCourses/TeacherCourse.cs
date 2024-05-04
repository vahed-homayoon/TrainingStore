using Shared.Entities;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Domain.TeacherCourses;

public sealed class TeacherCourse : BaseEntity
{
	private TeacherCourse(
		int courseId,
		int teacherId,
		DateTime startDate,
		DateTime endDate,
		TimeSpan fromHour,
		TimeSpan toHour)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		FromHour = fromHour;
		ToHour = toHour;
	}

	public DateTime StartDate { get; private set; }

	public DateTime EndDate { get; private set; }

	public TimeSpan FromHour { get; private set; }

	public TimeSpan ToHour { get; private set; }

	public int CourseId { get; private set; }

	public Course Course { get; private set; }

	public int TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static TeacherCourse Create(int courseId, int teacherId, DateTime startDate, DateTime endDate, TimeSpan fromHour, TimeSpan toHour)
	{
		var teacherCourse = new TeacherCourse(courseId, teacherId, startDate, endDate, fromHour, toHour);

		return teacherCourse;
	}

	public void Edit(int courseId, int teacherId, DateTime startDate, DateTime endDate, TimeSpan fromHour, TimeSpan toHour)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		FromHour = fromHour;
		ToHour = toHour;
	}
}