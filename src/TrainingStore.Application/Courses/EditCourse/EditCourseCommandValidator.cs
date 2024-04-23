using FluentValidation;

namespace TrainingStore.Application.Courses.EditCourse;

internal sealed class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
{
	public EditCourseCommandValidator()
	{
		RuleFor(c => c.Id)
			.NotEmpty();

		RuleFor(c => c.Name)
			.NotEmpty()
			.MaximumLength(50);

		RuleFor(c => c.Description)
			.NotEmpty()
			.MaximumLength(200);
	}
}
