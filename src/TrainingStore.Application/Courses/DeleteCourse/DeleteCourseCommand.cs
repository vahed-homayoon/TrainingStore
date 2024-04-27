using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.DeleteCourse;

public sealed record DeleteCourseCommand(int Id) : ICommand;
