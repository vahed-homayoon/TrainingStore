using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.EditStudent;

public sealed record EditStudentCommand(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Email,
	string Phone) : ICommand;