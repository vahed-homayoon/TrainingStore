using Shared.MediatR.Messaging;
using Shared.Results;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;
using Shared.Common.Enums;

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

		const string sql = """
			SELECT COUNT(Id)
			FROM TeacherCourses
			WHERE
				(@CourseId IS NULL OR CourseId = @CourseId)
				AND(@TeacherId IS NULL OR TeacherId = @TeacherId);

			SELECT 
				tc.Id,
				c.Name,
				t.NationalCode,
				t.FirstName,
				t.SureName,
				tc.StartDate,
				tc.EndDate
			FROM TeacherCourses AS tc
			INNER JOIN(
			SELECT 
				p.Id, 
				p.NationalCode,
				p.FirstName, 
				p.SureName
			FROM People AS p
			WHERE p.Type = @Type
			) AS t ON tc.TeacherId = t.Id
			INNER JOIN Courses AS c ON tc.CourseId = c.Id
			WHERE
			(@CourseId IS NULL OR CourseId = @CourseId)
			AND(@TeacherId IS NULL OR TeacherId = @TeacherId)
			ORDER BY tc.Id
			OFFSET @PageSize * (@Page - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		""";

		var result = await connection.QueryMultipleAsync(
			sql,
			new
			{
				Type = PersonType.Teacher,
				request.PageSize,
				request.Page,
				request.CourseId,
				request.TeacherId
			});

		int totalCount = result.ReadSingle<int>();
		var courses = result.Read<TeacherCourseListResponse>();

		var response = DataGridResponse<TeacherCourseListResponse>.Create(courses, totalCount);

		return Result<DataGridResponse<TeacherCourseListResponse>>.Success(response);
	}
}