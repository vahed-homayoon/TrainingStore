using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Students;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.GenericRepository;

namespace TrainingStore.Infrastructure.Students.Repository;

internal sealed class StudentRepository :
	GenericRepository<Student>,
	IStudentRepository
{
	public StudentRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<Student?> GetByNationalCodeAsync(string nationalCode, CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Student>()
			.FirstOrDefaultAsync(person => person.NationalCode == nationalCode, cancellationToken);
	}
}