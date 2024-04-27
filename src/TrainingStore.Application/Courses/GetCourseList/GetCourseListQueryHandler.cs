using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Application.Courses.GetCourseList;

internal sealed class GetCourseListQueryHandler
	: IQueryHandler<GetCourseListQuery, IReadOnlyList<CourseListResponse>>
{
	private readonly ICourseRepository _courseRepository;

	public GetCourseListQueryHandler(ICourseRepository courseRepository)
	{
		_courseRepository = courseRepository;
	}

	public async Task<Result<IReadOnlyList<CourseListResponse>>> Handle(
		GetCourseListQuery request,
		CancellationToken cancellationToken)
	{
		var courseList = await _courseRepository.GetCourseListAsync(cancellationToken);

		var response = courseList
			.Select(course => new CourseListResponse
			{
				Id = course.Id,
				Name = course.Name,
				Description = course.Description
			})
			.ToList();

		return Result<IReadOnlyList<CourseListResponse>>.Success<IReadOnlyList<CourseListResponse>>(response);
	}
}