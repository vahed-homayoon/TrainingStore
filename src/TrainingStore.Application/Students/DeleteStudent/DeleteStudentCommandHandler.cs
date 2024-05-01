using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.DeleteStudent;

internal sealed class DeleteStudentCommandHandler : ICommandHandler<DeleteStudentCommand>
{
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteStudentCommandHandler(
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		DeleteStudentCommand request,
		CancellationToken cancellationToken)
	{
		var student = await _studentRepository.FindByIdAsync(request.Id, cancellationToken);

		if (student is null)
		{
			return Result.Failure(StudentErrors.NotFound);
		}

		_studentRepository.Delete(student);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
