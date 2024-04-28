using Shared.DbContexts;
using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class AddCourseCommandHandler : ICommandHandler<AddCourseCommand>
{
	private readonly ICourseRepository _courseRepository;
	private readonly IUnitOfWork _unitOfWork;

	public AddCourseCommandHandler(
		ICourseRepository courseRepository,
		IUnitOfWork unitOfWork)
	{
		_courseRepository = courseRepository;
		_unitOfWork = unitOfWork;
	}

	public async Task<Result> Handle(
		AddCourseCommand request,
		CancellationToken cancellationToken)
	{
		var isDuplicatedName = await _courseRepository.IsDuplicatedName(0, request.Name, cancellationToken);

		if (isDuplicatedName)
		{
			return Result.Failure(CourseErrors.DuplicatedName);
		}

		var course = Course.Create(
			request.Name,
			request.Description);

		_courseRepository.Add(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return Result.Success();
	}
}
