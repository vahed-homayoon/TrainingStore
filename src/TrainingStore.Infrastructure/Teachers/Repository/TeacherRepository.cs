using TrainingStore.Domain.Teachers;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.GenericRepository;

namespace TrainingStore.Infrastructure.Teachers.Repository;

internal sealed class TeacherRepository :
	GenericRepository<Teacher>,
	ITeacherRepository
{
	public TeacherRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}
}