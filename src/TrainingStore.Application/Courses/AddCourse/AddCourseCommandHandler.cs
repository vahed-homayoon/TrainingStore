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
		var result = await _courseRepository.IsDuplicatedName(request.Name, cancellationToken);

		if (result is true)
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
