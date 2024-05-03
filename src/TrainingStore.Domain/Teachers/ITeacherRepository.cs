using Shared.DataGrids;

namespace TrainingStore.Domain.Teachers;

public interface ITeacherRepository
{
	Task<Teacher?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<Teacher?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	void Add(Teacher course);

	void Delete(Teacher course);
}