using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Students;
using TrainingStore.Infrastructure.Repository;

namespace TrainingStore.Infrastructure.Students.Repository;

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