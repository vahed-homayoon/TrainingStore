using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.GetCourseList;

public sealed record GetCourseListQuery() 
	: IQuery<IReadOnlyList<CourseListResponse>>;