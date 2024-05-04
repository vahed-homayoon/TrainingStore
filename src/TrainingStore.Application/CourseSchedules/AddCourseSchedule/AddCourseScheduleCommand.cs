using Shared.MediatR.Messaging;

namespace TrainingStore.Application.CourseSchedules.AddCourseSchedule;

public sealed record AddCourseScheduleCommand(
	int CourseId,
	int TeacherId,
	DateTime StartDate,
	DateTime EndDate,
	DateTime FromHour,
	DateTime ToHour) : ICommand;