using FluentValidation;

namespace TrainingStore.Application.Students.EditStudent;

internal sealed class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
{
	public EditStudentCommandValidator()
	{
		RuleFor(c => c.Id)
			.NotEmpty();

		RuleFor(c => c.NationalCode)
			.NotEmpty()
			.Length(10);

		RuleFor(c => c.FirstName)
			.NotEmpty()
			.MaximumLength(50);

		RuleFor(c => c.SureName)
			.NotEmpty()
			.MaximumLength(50);

		RuleFor(c => c.Phone)
			.MaximumLength(15);

		RuleFor(c => c.Email)
			.EmailAddress()
			.MaximumLength(50);
	}
}