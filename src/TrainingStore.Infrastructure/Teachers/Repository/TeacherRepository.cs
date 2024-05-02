using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Teachers;
using TrainingStore.Infrastructure.Repository;

namespace TrainingStore.Infrastructure.Teachers.Repository;

internal sealed class TeacherRepository :
	GenericRepository<Teacher>,
	ITeacherRepository
{
	public TeacherRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<bool> IsDuplicateNationalCode(
		int id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Teacher>()
			.AnyAsync(tacher => tacher.Id != id && tacher.NationalCode == nationalCode, cancellationToken);
	}
}