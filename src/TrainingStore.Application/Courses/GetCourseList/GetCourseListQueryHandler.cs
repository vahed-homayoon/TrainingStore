using Shared.MediatR.Messaging;
using Shared.Results;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;

namespace TrainingStore.Application.Courses.GetCourseList;

internal sealed class GetCourseListQueryHandler
	: IQueryHandler<GetCourseListQuery, DataGridResponse<CourseListResponse>>
{
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public GetCourseListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
	}

	public async Task<Result<DataGridResponse<CourseListResponse>>> Handle(
		GetCourseListQuery request,
		CancellationToken cancellationToken)
	{
		using IDbConnection connection = _sqlConnectionFactory.CreateConnection();

		const string sql = """
			SELECT COUNT(Id)
			FROM Courses
			WHERE(@Name IS NULL OR Name LIKE '%' + @Name + '%');

			SELECT Id, Name, Description, IsActive, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate
			FROM Courses
			WHERE(@Name IS NULL OR Name LIKE '%' + @Name + '%')
			ORDER BY Id
			OFFSET @PageSize * (@Page - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		""";

		var result = await connection.QueryMultipleAsync(
			sql,
			new
			{
				request.Name,
				request.PageSize,
				request.Page
			});

		int totalCount = result.ReadSingle<int>();
		var courses = result.Read<CourseListResponse>();

		var response = DataGridResponse<CourseListResponse>.Create(courses, totalCount);

		return Result<DataGridResponse<CourseListResponse>>.Success(response);
	}
}