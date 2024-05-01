using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Students;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class StudentRepository :
	GenericRepository<Student>,
	IStudentRepository
{
	public StudentRepository(TrainingDbContext dbContext)
		: base(dbContext)
	{
	}

	public async Task<bool> IsDuplicatedNationalCode(
		int id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Student>()
			.AnyAsync(tacher => tacher.Id != id && tacher.NationalCode == nationalCode, cancellationToken);
	}
}