﻿namespace TrainingStore.Application.Teachers.GetTeacherList;

public sealed record TeacherListResponse(
	int Id,
	string NationalCode,
	string FirstName,
	string SureName,
	string Email,
	string? CreatedBy,
	DateTime? CreatedDate,
	string? UpdatedBy,
	DateTime? UpdatedDate);