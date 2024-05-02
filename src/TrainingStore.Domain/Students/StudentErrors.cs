using Shared.Results;

namespace TrainingStore.Domain.Students;

public static class StudentErrors
{
	public static readonly Error DuplicateNationalCode = new(
		"Student.DuplicateNationalCode",
		"کد ملی تکراری هست");

	public static readonly Error NotFound = new(
		"Student.NotFound",
		"فرد مورد نظر وجود ندارد");
}