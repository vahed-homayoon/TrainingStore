using FluentValidation;
using TrainingStore.Application.Students.AddStudent;

namespace TrainingStore.Application.Students.AddStudent;

internal sealed class AddStudentCommandValidator : AbstractValidator<AddStudentCommand>
{
	public AddStudentCommandValidator()
	{
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
			.NotEmpty()
			.MaximumLength(15);

		RuleFor(c => c.Email)
			.EmailAddress()
			.MaximumLength(50);

		RuleFor(c => c.BirthDate)
			.NotEmpty();
	}
}