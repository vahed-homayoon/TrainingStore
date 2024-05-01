namespace TrainingStore.Application.Students.GetStudentList;

public sealed record StudentListResponse(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Email,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);