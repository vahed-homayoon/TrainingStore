using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Application.Courses.AddCourse;

public sealed record DeleteCourseCommand(int Id) : ICommand;
