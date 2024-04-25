using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.GetCourseById;

internal sealed class GetCourseByIdQueryHandler
	: IQueryHandler<GetCourseByIdQuery, CourseResponse>
{
	private readonly ICourseRepository _courseRepository;

	public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task<Result<CourseResponse>> Handle(
		GetCourseByIdQuery request,
		CancellationToken cancellationToken)
	{
		var course = await _courseRepository.GetByIdAsync(
			request.Id,
			cancellationToken);

		if (course is null)
		{
			return Result<CourseResponse>.Failure<CourseResponse>(CourseErrors.NotFound);
		}

		var response = new CourseResponse(
			course.Id,
			course.Name,
			course.Description);

		return Result<CourseResponse>.Success(response);
	}
}