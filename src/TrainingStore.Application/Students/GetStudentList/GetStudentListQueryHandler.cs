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

		const string sql = """
			SELECT COUNT(Id)
			FROM People
			WHERE
				Type= 'Student'
				AND (@NationalCode IS NULL OR NationalCode = @NationalCode)
				AND (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
				AND (@SureName IS NULL OR SureName LIKE '%' + @SureName + '%');

			SELECT Id, NationalCode, FirstName, SureName, Email, CreatedBy, CreatedDate, UpdatedBy, UpdatedDate
			FROM People
			WHERE 
				Type = 'Student'
				AND (@NationalCode IS NULL OR NationalCode = @NationalCode)
				AND (@FirstName IS NULL OR FirstName LIKE '%' + @FirstName + '%')
				AND (@SureName IS NULL OR SureName LIKE '%' + @SureName + '%')
			ORDER BY Id
			OFFSET @PageSize * (@Page - 1) ROWS
			FETCH NEXT @PageSize ROWS ONLY;
		""";

		var result = await connection.QueryMultipleAsync(
			sql,
			new
			{
				request.NationalCode,
				request.FirstName,
				request.SureName,
				request.PageSize,
				request.Page
			});

		int totalCount = result.ReadSingle<int>();
		var students = result.Read<StudentListResponse>();

		var response = DataGridResponse<StudentListResponse>.Create(students, totalCount);

		return Result<DataGridResponse<StudentListResponse>>.Success(response);
	}
}