using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.EditCourse;

internal sealed class EditCourseCommandHandler : ICommandHandler<EditCourseCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public EditCourseCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		EditCourseCommand request,
		CancellationToken cancellationToken)
	{
		var course = await _courseRepository.FindByIdAsync(request.Id, cancellationToken);

		if (course is null)
		{
			return Result.Failure(CourseErrors.NotFound);
		}

		course.Edit(
			request.Name,
			request.Description);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
