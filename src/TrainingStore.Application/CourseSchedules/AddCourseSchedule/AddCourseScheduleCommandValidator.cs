using FluentValidation;

namespace TrainingStore.Application.CourseSchedules.AddCourseSchedule;

internal sealed class AddCourseScheduleCommandValidator : AbstractValidator<AddCourseScheduleCommand>
{
	public AddCourseScheduleCommandValidator()
	{
		RuleFor(c => c.CourseId)
			.NotEmpty();

		RuleFor(c => c.TeacherId)
			.NotEmpty();

		RuleFor(c => c.StartDate)
			.NotEmpty();

		RuleFor(c => c.EndDate)
			.NotEmpty();

		RuleFor(c => c.FromHour)
			.NotEmpty();

		RuleFor(c => c.ToHour)
			.NotEmpty();
	}
}