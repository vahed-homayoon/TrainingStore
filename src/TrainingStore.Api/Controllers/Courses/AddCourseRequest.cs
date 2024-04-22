namespace TrainingStore.Api.Controllers.Courses;

public sealed record AddCourseRequest(Guid CourseId, string Name, string Description);
