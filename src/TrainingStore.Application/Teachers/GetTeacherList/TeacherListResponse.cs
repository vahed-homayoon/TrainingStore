namespace TrainingStore.Application.Teachers.GetTeacherList;

public sealed record TeacherListResponse(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Email,
	bool IsActive,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);