using Shared.Entities;

namespace TrainingStore.Domain.Session;

public sealed class Session : BaseEntity
{
	public DateTime StartDate { get; private set; }

	public DateTime? EndDate { get; private set; }
}