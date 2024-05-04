using Shared.MediatR.Messaging;
using Shared.Results;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;

namespace TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

internal sealed class GetTeacherCourseListQueryHandler
	: IQueryHandler<GetTeacherCourseListQuery, DataGridResponse<TeacherCourseListResponse>>
{
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public GetTeacherCourseListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
	}

	public async Task<Result<DataGridResponse<TeacherCourseListResponse>>> Handle(
		GetTeacherCourseListQuery request,
		CancellationToken cancellationToken)
	{
		using IDbConnection connection = _sqlConnectionFactory.CreateConnection();


		//WHERE
		//		Type = @Type
		//		AND(@NationalCode IS NULL OR NationalCode = @NationalCode)
		//		AND(@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
		//		AND(@SureName IS NULL OR SureName LIKE '%' + @SureName + '%')

		const string sql = """
			SELECT COUNT(Id)
			FROM TeacherCourses;

			SELECT 
				Id,
				CreatedBy,
				CreatedDate,
				UpdatedBy,
				UpdatedDate
			FROM TeacherCourses
			ORDER BY Id
			OFFSET @PageSize * (@Page - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		""";

		var result = await connection.QueryMultipleAsync(
			sql,
			new
			{
				request.TeacherId,
				request.PageSize,
				request.Page
			});

		int totalCount = result.ReadSingle<int>();
		var courses = result.Read<TeacherCourseListResponse>();

		var response = DataGridResponse<TeacherCourseListResponse>.Create(courses, totalCount);

		return Result<DataGridResponse<TeacherCourseListResponse>>.Success(response);
	}
}