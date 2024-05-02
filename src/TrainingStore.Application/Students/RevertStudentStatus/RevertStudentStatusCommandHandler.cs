using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Students;

namespace TrainingStore.Application.Students.RevertStudentStatus;

internal sealed class RevertStudentStatusCommandHandler : ICommandHandler<RevertStudentStatusCommand>
{
	private readonly IStudentRepository _studentRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RevertStudentStatusCommandHandler(
		IStudentRepository studentRepository,
		IUnitOfWork unitOfWork)
	{
		_studentRepository = studentRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		RevertStudentStatusCommand request,
		CancellationToken cancellationToken)
	{
		var student = await _studentRepository.FindByIdAsync(request.Id, cancellationToken);

		if (student is null)
		{
			return Result.Failure(StudentErrors.NotFound);
		}

		student.RevertStatus();

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
