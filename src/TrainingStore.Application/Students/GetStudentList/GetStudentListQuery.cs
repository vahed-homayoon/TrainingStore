using Shared.DataGrids;
using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Students.GetStudentList;

public sealed class GetStudentListQuery :
	DataGridRequest,
	IQuery<DataGridResponse<StudentListResponse>>
{
	public string? NationalCode { get; set; }
	public string? FirstName { get; set; }
	public string? SureName { get; set; }
}