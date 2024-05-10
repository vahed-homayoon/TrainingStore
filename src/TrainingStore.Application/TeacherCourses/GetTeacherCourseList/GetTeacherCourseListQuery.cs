using Shared.DataGrids;
using Shared.MediatR.Messaging;

namespace TrainingStore.Application.TeacherCourses.GetTeacherCourseList;

public sealed class GetTeacherCourseListQuery :
	DataGridRequest,
	IQuery<DataGridResponse<TeacherCourseListResponse>>
{
	public Guid? CourseId { get; set; }
	public int? TeacherId { get; set; }
}