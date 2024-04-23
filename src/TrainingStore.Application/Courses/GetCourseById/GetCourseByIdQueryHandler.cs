using TrainingStore.Application.Abstractions.Messaging;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Bookings;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.GetCourse;

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
			request.CourseId,
			cancellationToken);

		if (course is null)
		{
			return Result.Failure<CourseResponse>(CourseErrors.NotFound);
		}

		var response = new CourseResponse(
			course.Id,
			course.Name,
			course.Description);

		return response;
	}
}