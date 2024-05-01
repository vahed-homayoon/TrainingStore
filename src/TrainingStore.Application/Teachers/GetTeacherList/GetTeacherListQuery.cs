using Shared.DataGrids;
using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Teachers.GetTeacherList;

public sealed class GetTeacherListQuery:
	DataGridRequest,
	IQuery<DataGridResponse<TeacherListResponse>>
{
	public string? NationalCode { get; set; }
	public string? FirstName { get; set; }
	public string? SureName { get; set; }
}