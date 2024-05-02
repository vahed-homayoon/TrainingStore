using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.RevertCourseStatus;

public sealed record RevertCourseStatusCommand(int Id) : ICommand;
