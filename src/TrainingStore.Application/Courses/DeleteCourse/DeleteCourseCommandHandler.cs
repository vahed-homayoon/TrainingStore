using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Bookings;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class DeleteCourseCommandHandler : ICommandHandler<DeleteCourseCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public DeleteCourseCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		DeleteCourseCommand request,
		CancellationToken cancellationToken)
	{
		var course = await _courseRepository.GetByIdAsync(request.Id, cancellationToken);

		if (course is null)
		{
			return Result.Failure(CourseErrors.NotFound);
		}

		_courseRepository.Delete(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
