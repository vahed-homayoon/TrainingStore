using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Teachers;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class TeacherRepository:
	GenericRepository<Teacher>,
	ITeacherRepository
{
	public TeacherRepository(TrainingDbContext dbContext)
		: base(dbContext)
	{
	}

	public async Task<bool> IsDuplicatedNationalCode(
		int id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Teacher>()
			.AnyAsync(tacher => tacher.Id != id && tacher.NationalCode == nationalCode, cancellationToken);
	}
}