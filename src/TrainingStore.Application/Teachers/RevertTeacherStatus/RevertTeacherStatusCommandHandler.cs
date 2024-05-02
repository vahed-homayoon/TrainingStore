using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.RevertTeacherStatus;

internal sealed class RevertTeacherStatusCommandHandler : ICommandHandler<RevertTeacherStatusCommand>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RevertTeacherStatusCommandHandler(
		ITeacherRepository teacherRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = teacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		RevertTeacherStatusCommand request,
		CancellationToken cancellationToken)
	{
		var teacher = await _teacherRepository.FindByIdAsync(request.Id, cancellationToken);

		if (teacher is null)
		{
			return Result.Failure(TeacherErrors.NotFound);
		}

		teacher.RevertStatus();

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
