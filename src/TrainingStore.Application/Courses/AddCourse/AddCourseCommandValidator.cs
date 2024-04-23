using FluentValidation;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
{
	public AddCourseCommandValidator()
	{
		RuleFor(c => c.Name)
			.NotEmpty()
			.MaximumLength(50);

		RuleFor(c => c.Description)
			.NotEmpty()
			.MaximumLength(200);
	}
}