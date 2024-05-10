using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.EditStudent;

public sealed record EditStudentCommand(
	Guid Id,
	string NationalCode,
	string FirstName,
	string SureName,
	DateTime BirthDate,
	string Phone,
	string Email) : ICommand;