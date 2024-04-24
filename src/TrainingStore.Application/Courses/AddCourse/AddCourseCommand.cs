using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.AddCourse;

public sealed record AddCourseCommand(
	string Name,
	string Description) : ICommand;