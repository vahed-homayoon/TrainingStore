namespace TrainingStore.Domain.Courses;

public interface ICourseRepository
{
	Task<Course?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<Course?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateName(int id, string name, CancellationToken cancellationToken = default);

	void Add(Course course);

	void Delete(Course course);
}