using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.AddTeacher;

public sealed record AddTeacherCommand(
	string NationalCode,
	string FirstName,
	string SureName,
	string Phone,
	string Email,
	string Address) : ICommand;