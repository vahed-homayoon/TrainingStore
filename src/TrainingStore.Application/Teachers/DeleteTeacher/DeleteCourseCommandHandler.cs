using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Application.Teachers.DeleteTeacher;

internal sealed class DeleteTeacherCommandHandler : ICommandHandler<DeleteTeacherCommand>
{
	private readonly ITeacherRepository _teacherRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteTeacherCommandHandler(
		ITeacherRepository teacherRepository,
		IUnitOfWork unitOfWork)
	{
		_teacherRepository = teacherRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		DeleteTeacherCommand request,
		CancellationToken cancellationToken)
	{
		var teacher = await _teacherRepository.FindByIdAsync(request.Id, cancellationToken);

		if (teacher is null)
		{
			return Result.Failure(TeacherErrors.NotFound);
		}

		_teacherRepository.Delete(teacher);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
