using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.GetCourseById;

public sealed record GetCourseByIdQuery(int Id) : IQuery<CourseResponse>;