using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.AddCourse;

internal sealed class AddCourseCommandHandler : ICommandHandler<AddCourseCommand, Guid>
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

	public async Task<Result<Guid>> Handle(
		AddCourseCommand request,
		CancellationToken cancellationToken)
	{
		var course = Course.Create(
			request.Name,
			request.Description);

		_courseRepository.Add(course);

		await _unitOfWork.SaveChangesAsync(cancellationToken);

		return course.Id;
	}
}
