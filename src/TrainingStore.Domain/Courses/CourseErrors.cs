using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Domain.Bookings;

public static class CourseErrors
{
	public static readonly Error Found = new(
		"Course.Found",
		"درس مورد نظر وجود دارد");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"درس مورد نظر وجود ندارد");
}