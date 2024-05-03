using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.EditStudent;

internal sealed class EditStudentCommandHandler : ICommandHandler<EditStudentCommand>
{
	private readonly IPersonRepository _personRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditStudentCommandHandler(
		IPersonRepository personRepository,
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_personRepository = personRepository;
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditStudentCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicateNationalCode = await _personRepository.IsDuplicateNationalCode(request.Id, request.NationalCode, cancellationToken);

		if (isDuplicateNationalCode)
		{
			return Result.Failure(StudentErrors.DuplicateNationalCode);
		}

		var student = await _studentRepository.FindByIdAsync(request.Id, cancellationToken);

		if (student is null)
		{
			return Result.Failure(StudentErrors.NotFound);
		}

		student.Edit(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.BirthDate,
			request.Phone,
			request.Email);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}