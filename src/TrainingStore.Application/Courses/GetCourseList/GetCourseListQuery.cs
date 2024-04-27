using Shared.MediatR.Messaging;

namespace TrainingStore.Application.Courses.GetCourseList;

public sealed record GetCourseListQuery() 
	: IQuery<IReadOnlyList<CourseListResponse>>;