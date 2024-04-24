using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Application.Courses.DeleteCourse;

public sealed record DeleteCourseCommand(int Id) : ICommand;
