using Shared.DataGrids;

namespace TrainingStore.Domain.Sessions;

public interface ISessionRepository
{
	Task<Session?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<Session?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateName(int id, string name, CancellationToken cancellationToken = default);

	void Add(Session session);

	void Delete(Session session);
}