using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.DeleteStudent;

public sealed record DeleteStudentCommand(int Id) : ICommand;