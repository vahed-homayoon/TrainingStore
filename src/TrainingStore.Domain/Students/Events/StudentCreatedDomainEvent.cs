using Shared.DomainEvent;

namespace TrainingStore.Domain.Students.Events;

public sealed record StudentCreatedDomainEvent(string NationalCode) : IDomainEvent;