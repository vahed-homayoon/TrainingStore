namespace TrainingStore.Domain.Courses;

public interface ICourseRepository
{
	Task<Course?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<Course?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateName(Guid id, string name, CancellationToken cancellationToken = default);

	void Add(Course course);

	void Delete(Course course);
}