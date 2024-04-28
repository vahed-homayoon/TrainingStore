using Shared.MediatR.Messaging;
using Shared.Results;
using TrainingStore.Domain.Courses;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;

namespace TrainingStore.Application.Courses.GetCourseList;

internal sealed class GetCourseListQueryHandler
	: IQueryHandler<GetCourseListQuery, PagedList<CourseListResponse>>
{
	private readonly ICourseRepository _courseRepository;
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public GetCourseListQueryHandler(ICourseRepository courseRepository, ISqlConnectionFactory sqlConnectionFactory)
	{
		_courseRepository = courseRepository;
		_sqlConnectionFactory = sqlConnectionFactory;
	}


	public async Task<Result<PagedList<CourseListResponse>>> Handle(
		GetCourseListQuery request,
		CancellationToken cancellationToken)
	{
		using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

		const string sql = """
				WITH CTE AS (
				    SELECT 
				        Id, 
				        Name,
				        Description,
				        COUNT(*) OVER() AS TotalCount
				    FROM Courses
				    WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%')
				)
				SELECT * 
				FROM CTE
				ORDER BY Id
				OFFSET @PageSize * (@Page - 1) ROWS
				FETCH NEXT @PageSize ROWS ONLY
				""";

		int totalCount = 0;

		var result = await connection.QueryAsync<CourseListResponse, int, CourseListResponse>(sql,
			(course, count) =>
			{
				totalCount = count;
				return course;

			},
			new
			{
				request.Name,
				request.PageSize,
				request.Page
			},
			splitOn: "TotalCount"
			);

		var response = PagedList<CourseListResponse>.List(result.ToList(), totalCount);

		return Result<PagedList<CourseListResponse>>.Success(response);
	}
}