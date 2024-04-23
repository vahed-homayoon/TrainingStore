using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Abstractions;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class CourseRepository : GenericRepository<Course>, ICourseRepository
{
	public CourseRepository(TrainingDbContext dbContext)
		: base(dbContext)
	{
	}

	public async Task<Course?> GetByNameAsync(
		string name,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Course>()
			.AsNoTracking()
			.FirstOrDefaultAsync(course => course.Name == name, cancellationToken);
	}

	public void Edit(Course course)
	{
		DbContext.Update<Course>(course);
	}

	public void Delete(Course course)
	{
		DbContext.Remove<Course>(course);
	}
}