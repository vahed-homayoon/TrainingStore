using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class CourseRepository : Repository<Course>, ICourseRepository
{
	public CourseRepository(ApplicationDbContext dbContext)
		: base(dbContext)
	{
	}
}
