using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.AddTeacher;

internal sealed class AddTeacherCommandHandler : ICommandHandler<AddTeacherCommand>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddTeacherCommandHandler(
		ITeacherRepository TeacherRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = TeacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddTeacherCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicatedNationalCode = await _teacherRepository.IsDuplicatedNationalCode(0, request.NationalCode, cancellationToken);

		if (isDuplicatedNationalCode)
		{
			return Result.Failure(TeacherErrors.DuplicatedNationalCode);
		}

		var teacher = Teacher.Create(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.Email,
			request.Phone,
			request.Address);

		_teacherRepository.Add(teacher);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}