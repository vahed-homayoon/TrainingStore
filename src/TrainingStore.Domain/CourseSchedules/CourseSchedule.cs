using Shared.Entities;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Domain.CourseSchedules;

public sealed class CourseSchedule : BaseEntity
{
	private CourseSchedule(
		int courseId,
		int teacherId,
		DateTime startDate,
		DateTime endDate,
		DateTime fromHour,
		DateTime toHour)
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

	public DateTime FromHour { get; private set; }

	public DateTime ToHour { get; private set; }

	public int CourseId { get; private set; }

	public Course Course { get; private set; }

	public int TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static CourseSchedule Create(int courseId, int teacherId, DateTime startDate, DateTime endDate, DateTime fromHour, DateTime toHour)
	{
		var courseSchedule = new CourseSchedule(courseId, teacherId, startDate, endDate, fromHour, toHour);

		return courseSchedule;
	}

	public void Edit(int courseId, int teacherId, DateTime startDate, DateTime endDate, DateTime fromHour, DateTime toHour)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		FromHour = fromHour;
		ToHour = toHour;
	}
}