using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Application.Courses.EditCourse;

public sealed record EditCourseCommand(
	int Id,
	string Name,
	string Description) : ICommand;