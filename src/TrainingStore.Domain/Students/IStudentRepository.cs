namespace TrainingStore.Domain.Students;

public interface IStudentRepository
{
	Task<Student?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
	
	Task<Student?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

	void Add(Student course);

	void Delete(Student course);
}