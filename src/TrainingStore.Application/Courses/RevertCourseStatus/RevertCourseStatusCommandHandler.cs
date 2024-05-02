using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.RevertCourseStatus;

internal sealed class RevertCourseStatusCommandHandler : ICommandHandler<RevertCourseStatusCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public RevertCourseStatusCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		RevertCourseStatusCommand request,
		CancellationToken cancellationToken)
	{
		var course = await _courseRepository.FindByIdAsync(request.Id, cancellationToken);

		if (course is null)
		{
			return Result.Failure(CourseErrors.NotFound);
		}

		course.RevertStatus();

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
