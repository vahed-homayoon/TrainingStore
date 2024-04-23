using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    public CourseRepository(TrainingDbContext dbContext)
        : base(dbContext)
    {
    }
}
