using Shared.Results;

namespace TrainingStore.Domain.Courses;

public static class TeacherErrors
{
	public static readonly Error DuplicatedNationalCode = new(
		"Course.DuplicatedNationalCode",
		"کد ملی تکراری هست");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"فرد مورد نظر وجود ندارد");
}