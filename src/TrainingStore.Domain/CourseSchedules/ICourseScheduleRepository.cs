namespace TrainingStore.Domain.CourseSchedules;

public interface ICourseScheduleRepository
{
	Task<CourseSchedule?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<CourseSchedule?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateName(int id, string name, CancellationToken cancellationToken = default);

	void Add(CourseSchedule courseSchedule);

	void Delete(CourseSchedule courseSchedule);
}