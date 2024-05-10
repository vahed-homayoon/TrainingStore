namespace TrainingStore.Domain.People;

public interface IPersonRepository
{
	Task<bool> IsDuplicateNationalCode(Guid id, string name, CancellationToken cancellationToken = default);
}