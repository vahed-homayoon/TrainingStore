using Shared.MediatR.Messaging;
using Shared.Results;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;

namespace TrainingStore.Application.Teachers.GetTeacherList;

internal sealed class GetTeacherListQueryHandler
	: IQueryHandler<GetTeacherListQuery, DataGridResponse<TeacherListResponse>>
{
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public GetTeacherListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
	}

	public async Task<Result<DataGridResponse<TeacherListResponse>>> Handle(
		GetTeacherListQuery request,
		CancellationToken cancellationToken)
	{
		using IDbConnection connection = _sqlConnectionFactory.CreateConnection();
		try
		{
			const string sql = """
				WITH CTE AS (
				    SELECT 
				        Id,
						NationalCode,
				        FirstName,
				        SureName,
						Email,
						CreateBy,
						CreateDate,
						UpdateBy,
						UpdateDate,
				        COUNT(*) OVER() AS TotalCount
				    FROM People
				    WHERE (@NationalCode IS NULL OR NationalCode LIKE '%' + @NationalCode + '%' OR @FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%' OR @SureName IS NULL OR SureName LIKE '%' + @SureName + '%')
				)
				SELECT * 
				FROM CTE
				ORDER BY Id
				OFFSET @PageSize * (@Page - 1) ROWS
				FETCH NEXT @PageSize ROWS ONLY
				""";

			int totalCount = 0;

			var result = (await connection.QueryAsync<TeacherListResponse, int, TeacherListResponse>(sql,
				(teacher, count) =>
				{
					totalCount = count;
					return teacher;
				},
				new
				{
					request.NationalCode,
					request.FirstName,
					request.SureName,
					request.PageSize,
					request.Page
				},
				splitOn: "TotalCount"
				)).ToList();

			var response = DataGridResponse<TeacherListResponse>.Create(result, totalCount);

			return Result<DataGridResponse<TeacherListResponse>>.Success(response);

		}
		catch (Exception ex)
		{

			throw;
		}
	}
}