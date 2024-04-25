using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Courses;

public static class CourseErrors
{
	public static readonly Error DuplicatedName = new(
		"Course.DuplicatedName",
		"نام درس تکراری است");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"درس مورد نظر وجود ندارد");
}