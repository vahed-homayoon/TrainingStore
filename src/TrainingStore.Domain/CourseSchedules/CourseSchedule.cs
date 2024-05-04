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
		DateTime toHour,
		List<DayOfWeek> weekDays)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		FromHour = fromHour;
		ToHour = toHour;
		WeekDays = weekDays;
	}

	public DateTime StartDate { get; private set; }

	public DateTime EndDate { get; private set; }

	public DateTime FromHour { get; private set; }

	public DateTime ToHour { get; private set; }

	public List<DayOfWeek> WeekDays { get; private set; }

	public int CourseId { get; private set; }

	public Course Course { get; private set; }

	public int TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static CourseSchedule Create(int courseId, int teacherId, DateTime startDate, DateTime endDate, DateTime fromHour, DateTime toHour, List<DayOfWeek> weekDays)
	{
		var courseSchedule = new CourseSchedule(courseId, teacherId, startDate, endDate, fromHour, toHour, weekDays);

		return courseSchedule;
	}

	public void Edit(int courseId, int teacherId, DateTime startDate, DateTime endDate, DateTime fromHour, DateTime toHour, List<DayOfWeek> weekDays)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
		FromHour = fromHour;
		ToHour = toHour;
		WeekDays = weekDays;
	}
}