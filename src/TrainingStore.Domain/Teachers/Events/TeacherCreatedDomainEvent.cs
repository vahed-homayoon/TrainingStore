using Shared.Entities;

namespace TrainingStore.Domain.Teachers.Events;

public sealed record TeacherCreatedDomainEvent(Guid Id) : IDomainEvent;