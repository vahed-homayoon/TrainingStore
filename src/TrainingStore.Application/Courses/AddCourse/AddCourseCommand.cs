using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.AddCourse;

public sealed record AddCourseCommand(
	Guid CourseId,
	string Name,
	string Description) : ICommand<Guid>;
