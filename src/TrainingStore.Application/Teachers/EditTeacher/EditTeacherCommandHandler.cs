using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.EditTeacher;

internal sealed class EditTeacherCommandHandler : ICommandHandler<EditTeacherCommand>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditTeacherCommandHandler(
		ITeacherRepository teacherRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = teacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditTeacherCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicatedNationalCode = await _teacherRepository.IsDuplicatedNationalCode(request.Id, request.NationalCode, cancellationToken);

		if (isDuplicatedNationalCode)
		{
			return Result.Failure(TeacherErrors.DuplicatedNationalCode);
		}

		var teacher = await _teacherRepository.FindByIdAsync(request.Id, cancellationToken);

		if (teacher is null)
		{
			return Result.Failure(TeacherErrors.NotFound);
		}

		teacher.Edit(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.Email,
			request.Phone,
			request.Address);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
