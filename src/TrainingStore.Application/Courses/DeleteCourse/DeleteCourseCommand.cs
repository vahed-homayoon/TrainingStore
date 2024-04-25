using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.DeleteCourse;

public sealed record DeleteCourseCommand(int Id) : ICommand;
