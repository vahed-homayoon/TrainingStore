﻿namespace TrainingStore.Domain.Students;

public interface IStudentRepository
{
	Task<Student?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<Student?> FindByIdAsync(int id, CancellationToken cancellationToken = default);

	Task<bool> IsDuplicateNationalCode(int id, string name, CancellationToken cancellationToken = default);

	void Add(Student course);

	void Delete(Student course);
}