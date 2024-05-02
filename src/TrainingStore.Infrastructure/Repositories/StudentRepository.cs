using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Students;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class StudentRepository :
	GenericRepository<Student>,
	IStudentRepository
{
	public StudentRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<bool> IsDuplicateNationalCode(
		int id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Student>()
			.AnyAsync(student => student.Id != id && student.NationalCode == nationalCode, cancellationToken);
	}
}