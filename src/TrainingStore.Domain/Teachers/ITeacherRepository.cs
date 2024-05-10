namespace TrainingStore.Domain.Teachers;

public interface ITeacherRepository
{
	Task<Teacher?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<Teacher?> FindByIdAsync(Guid id, CancellationToken cancellationToken = default);

	void Add(Teacher course);

	void Delete(Teacher course);
}