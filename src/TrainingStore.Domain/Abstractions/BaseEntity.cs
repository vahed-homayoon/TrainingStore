namespace TrainingStore.Domain.Abstractions;

public abstract class BaseEntity
{
    private readonly List<IDomainEvent> _domainEvents = new();

    protected BaseEntity(Guid id)
    {
        Id = id;
    }

    protected BaseEntity()
    {
    }

    public Guid Id { get; init; }

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
