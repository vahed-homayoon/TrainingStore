using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.EditCourse;

public sealed record EditCourseCommand(
	int Id,
	string Name,
	string Description) : ICommand;