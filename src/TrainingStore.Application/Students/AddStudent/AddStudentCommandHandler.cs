using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.AddStudent;

internal sealed class AddStudentCommandHandler : ICommandHandler<AddStudentCommand>
{
	private readonly IPersonRepository _personRepository;
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddStudentCommandHandler(
		IPersonRepository personRepository,
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_personRepository = personRepository;
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddStudentCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicateNationalCode = await _personRepository.IsDuplicateNationalCode(0, request.NationalCode, cancellationToken);

		if (isDuplicateNationalCode)
		{
			return Result.Failure(StudentErrors.DuplicateNationalCode);
		}

		var student = Student.Create(
			request.NationalCode,
			request.FirstName,
			request.SureName,
			request.BirthDate,
			request.Phone,
			request.Email);

		_studentRepository.Add(student);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}