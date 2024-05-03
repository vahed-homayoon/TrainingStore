using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.EditTeacher;

internal sealed class EditTeacherCommandHandler : ICommandHandler<EditTeacherCommand>
{
	private readonly IPersonRepository _personRepository;
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditTeacherCommandHandler(
		IPersonRepository personRepository,
		ITeacherRepository teacherRepository,
		IUnitOfWork unitOfWork)
	{
		_personRepository = personRepository;
		_teacherRepository = teacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditTeacherCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicateNationalCode = await _personRepository.IsDuplicateNationalCode(request.Id, request.NationalCode, cancellationToken);

		if (isDuplicateNationalCode)
		{
			return Result.Failure(TeacherErrors.DuplicateNationalCode);
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
			request.Phone,
			request.Email,
			request.Address);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}