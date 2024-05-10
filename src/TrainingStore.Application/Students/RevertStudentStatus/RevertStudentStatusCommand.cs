using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.RevertStudentStatus;

public sealed record RevertStudentStatusCommand(Guid Id) : ICommand;
