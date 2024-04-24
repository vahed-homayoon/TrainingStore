using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Courses;

public static class CourseErrors
{
	public static readonly Error DuplicatedName = new(
		"Course.DuplicatedName",
		"درس مورد نظر وجود دارد");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"درس مورد نظر وجود ندارد");
}