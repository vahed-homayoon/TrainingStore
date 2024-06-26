﻿using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.AddStudent;

public sealed record AddStudentCommand(
	string NationalCode,
	string FirstName,
	string SureName,
	DateTime BirthDate,
	string Phone,
	string Email) : ICommand;