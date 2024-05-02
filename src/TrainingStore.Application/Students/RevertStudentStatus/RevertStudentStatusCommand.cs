using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.RevertStudentStatus;

public sealed record RevertStudentStatusCommand(int Id) : ICommand;
