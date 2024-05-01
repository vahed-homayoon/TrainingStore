using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.AddStudent;

internal sealed class AddStudentCommandHandler : ICommandHandler<AddStudentCommand>
{
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddStudentCommandHandler(
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddStudentCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicatedNationalCode = await _studentRepository.IsDuplicatedNationalCode(0, request.NationalCode, cancellationToken);

		if (isDuplicatedNationalCode)
		{
			return Result.Failure(StudentErrors.DuplicatedNationalCode);
		}

		var student = Student.Create(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.Email,
			request.Phone);

		_studentRepository.Add(student);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}