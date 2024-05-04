using TrainingStore.Domain.Students;
using TrainingStore.Infrastructure.Data;
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
}