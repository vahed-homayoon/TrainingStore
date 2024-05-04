using System.Numerics;

namespace TrainingStore.Application.Students.GetStudentList;

public sealed record StudentListResponse(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	DateTime BirthDate,
	string Phone,
	string Email,
	bool IsActive,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);