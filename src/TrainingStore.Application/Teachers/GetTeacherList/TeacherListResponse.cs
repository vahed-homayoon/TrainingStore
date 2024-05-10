namespace TrainingStore.Application.Teachers.GetTeacherList;

public sealed record TeacherListResponse(
	Guid Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Phone,
	string Email,
	bool IsActive,
	string CreatedBy,
	DateTime CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);