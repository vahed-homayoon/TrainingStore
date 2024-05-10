using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.RevertTeacherStatus;

public sealed record RevertTeacherStatusCommand(Guid Id) : ICommand;
