
using TrainingStore.Application.Abstractions.Messaging;

namespace TrainingStore.Application.Courses.GetCourse;

public sealed record GetCourseByIdQuery(Guid CourseId) : IQuery<CourseResponse>;