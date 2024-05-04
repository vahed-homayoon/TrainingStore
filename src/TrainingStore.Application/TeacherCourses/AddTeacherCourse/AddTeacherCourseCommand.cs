using Shared.MediatR.Messaging;

namespace TrainingStore.Application.TeacherCourses.AddTeacherCourse;

public sealed record AddTeacherCourseCommand(
	int CourseId,
	int TeacherId,
	DateTime StartDate,
	DateTime EndDate,
	TimeSpan FromHour,
	TimeSpan ToHour) : ICommand;