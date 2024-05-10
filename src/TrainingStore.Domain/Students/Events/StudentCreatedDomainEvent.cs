using Shared.Entities;

namespace TrainingStore.Domain.Students.Events;

public sealed record StudentCreatedDomainEvent(Guid Id) : IDomainEvent;