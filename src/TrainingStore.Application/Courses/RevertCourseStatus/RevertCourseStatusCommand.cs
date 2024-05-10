using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.RevertCourseStatus;

public sealed record RevertCourseStatusCommand(Guid Id) : ICommand;
