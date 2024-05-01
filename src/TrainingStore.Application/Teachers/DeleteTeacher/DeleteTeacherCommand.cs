using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.DeleteTeacher;

public sealed record DeleteTeacherCommand(int Id) : ICommand;