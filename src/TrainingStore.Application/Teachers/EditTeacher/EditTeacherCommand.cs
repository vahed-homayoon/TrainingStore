using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.EditTeacher;

public sealed record EditTeacherCommand(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Phone,
	string Email,
	string Address) : ICommand;