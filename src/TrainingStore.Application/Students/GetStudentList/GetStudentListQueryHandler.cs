using Shared.MediatR.Messaging;
using Shared.Results;
using Dapper;
using Shared.DataGrids;
using Shared.Data;
using System.Data;

namespace TrainingStore.Application.Students.GetStudentList;

internal sealed class GetStudentListQueryHandler
	: IQueryHandler<GetStudentListQuery, DataGridResponse<StudentListResponse>>
{
	private readonly ISqlConnectionFactory _sqlConnectionFactory;

	public GetStudentListQueryHandler(ISqlConnectionFactory sqlConnectionFactory)
	{
		_sqlConnectionFactory = sqlConnectionFactory;
	}

	public async Task<Result<DataGridResponse<StudentListResponse>>> Handle(
		GetStudentListQuery request,
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
						CreatedBy,
						CreatedDate,
						UpdatedBy,
						UpdatedDate,
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

			var result = (await connection.QueryAsync<StudentListResponse, int, StudentListResponse>(sql,
				(student, count) =>
				{
					totalCount = count;
					return student;
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

			var response = DataGridResponse<StudentListResponse>.Create(result, totalCount);

			return Result<DataGridResponse<StudentListResponse>>.Success(response);

		}
		catch (Exception ex)
		{

			throw;
		}
	}
}