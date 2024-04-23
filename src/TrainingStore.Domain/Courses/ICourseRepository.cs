using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Courses;

public interface ICourseRepository
{
	Task<Course?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<Course?> GetByNameAsync(string name, CancellationToken cancellationToken = default);

	void Add(Course course);

	void Edit(Course course);
	
	void Delete(Course course);
}