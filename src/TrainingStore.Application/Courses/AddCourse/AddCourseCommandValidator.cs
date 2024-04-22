using FluentValidation;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
{
	public AddCourseCommandValidator()
	{
		RuleFor(c => c.Name).NotEmpty().MinimumLength(15);

		RuleFor(c => c.Description).NotEmpty().MinimumLength(20);
	}
}
