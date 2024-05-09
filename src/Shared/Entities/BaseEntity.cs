using Shared.DomainEvent;

namespace Shared.Entities;

public abstract class BaseEntity
{
	private readonly List<IDomainEvent> _domainEvents = new();

	protected BaseEntity(int id)
	{
		Id = id;
	}

	protected BaseEntity()
	{
	}

	public int Id { get; init; }

	public IReadOnlyList<IDomainEvent> GetDomainEvents()
	{
		return _domainEvents.ToList();
	}

	public void ClearDomainEvents()
	{
		_domainEvents.Clear();
	}

	protected void RaiseDomainEvent(IDomainEvent domainEvent)
	{
		_domainEvents.Add(domainEvent);
	}
}
