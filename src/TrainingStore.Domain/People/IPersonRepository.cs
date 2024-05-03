namespace TrainingStore.Domain.People;

public interface IPersonRepository
{
	Task<bool> IsDuplicateNationalCode(int id, string name, CancellationToken cancellationToken = default);
}