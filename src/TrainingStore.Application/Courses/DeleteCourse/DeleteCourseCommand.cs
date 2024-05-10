using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.DeleteCourse;

public sealed record DeleteCourseCommand(Guid Id) : ICommand;
