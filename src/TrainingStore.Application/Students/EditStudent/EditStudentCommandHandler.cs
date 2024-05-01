using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.EditStudent;

internal sealed class EditStudentCommandHandler : ICommandHandler<EditStudentCommand>
{
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditStudentCommandHandler(
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditStudentCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicatedNationalCode = await _studentRepository.IsDuplicatedNationalCode(request.Id, request.NationalCode, cancellationToken);

		if (isDuplicatedNationalCode)
		{
			return Result.Failure(StudentErrors.DuplicatedNationalCode);
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
			request.Email,
			request.Phone);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
