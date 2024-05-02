using Shared.Results;

namespace TrainingStore.Domain.Teachers;

public static class TeacherErrors
{
	public static readonly Error DuplicateNationalCode = new(
		"Teacher.DuplicateNationalCode",
		"کد ملی تکراری هست");

	public static readonly Error NotFound = new(
		"Teacher.NotFound",
		"فرد مورد نظر وجود ندارد");
}