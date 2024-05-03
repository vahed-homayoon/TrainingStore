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
}