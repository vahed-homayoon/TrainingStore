using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.EditTeacher;

public sealed record EditTeacherCommand(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Email,
	string Phone,
	string Address) : ICommand;