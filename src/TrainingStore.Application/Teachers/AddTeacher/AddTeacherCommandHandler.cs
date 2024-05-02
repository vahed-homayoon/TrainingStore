﻿using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.AddTeacher;

internal sealed class AddTeacherCommandHandler : ICommandHandler<AddTeacherCommand>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddTeacherCommandHandler(
		ITeacherRepository teacherRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = teacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddTeacherCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicateNationalCode = await _teacherRepository.IsDuplicateNationalCode(0, request.NationalCode, cancellationToken);

		if (isDuplicateNationalCode)
		{
			return Result.Failure(TeacherErrors.DuplicateNationalCode);
		}

		var teacher = Teacher.Create(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.Phone,
			request.Email,
			request.Address);

		_teacherRepository.Add(teacher);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}