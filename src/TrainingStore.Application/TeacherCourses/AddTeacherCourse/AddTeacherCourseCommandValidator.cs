using FluentValidation;

namespace TrainingStore.Application.TeacherCourses.AddTeacherCourse;

internal sealed class AddTeacherCourseCommandValidator : AbstractValidator<AddTeacherCourseCommand>
{
	public AddTeacherCourseCommandValidator()
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