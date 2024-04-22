namespace TrainingStore.Domain.Courses;

public interface ICourseRepository
{
	Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	void Add(Course user);
}