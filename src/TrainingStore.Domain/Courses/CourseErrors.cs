using Shared.Results;

namespace TrainingStore.Domain.Courses;

public static class CourseErrors
{
	public static readonly Error DuplicateName = new(
		"Course.DuplicateName",
		"نام درس تکراری است");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"درس مورد نظر وجود ندارد");
}