using Shared.Entities;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Domain.Sessions;

public sealed class Session : BaseEntity
{
	private Session(
		int courseId,
		int teacherId,
		DateTime startDate,
		DateTime? endDate
)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
	}

	public DateTime StartDate { get; private set; }

	public DateTime? EndDate { get; private set; }

	public int CourseId { get; private set; }

	public Course Course { get; private set; }

	public int TeacherId { get; private set; }

	public Teacher Teacher { get; private set; }

	public static Session Create(int courseId, int teacherId, DateTime startDate, DateTime? endDate)
	{
		var session = new Session(courseId, teacherId,startDate, endDate);

		return session;
	}

	public void Edit(int courseId, int teacherId, DateTime startDate, DateTime? endDate)
	{
		CourseId = courseId;
		TeacherId = teacherId;
		StartDate = startDate;
		EndDate = endDate;
	}
}