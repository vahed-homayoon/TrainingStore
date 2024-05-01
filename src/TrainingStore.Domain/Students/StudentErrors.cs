using Shared.Results;

namespace TrainingStore.Domain.Students;

public static class StudentErrors
{
	public static readonly Error DuplicatedNationalCode = new(
		"Course.DuplicatedNationalCode",
		"کد ملی تکراری هست");

	public static readonly Error NotFound = new(
		"Course.NotFound",
		"فرد مورد نظر وجود ندارد");
}