using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Courses;

namespace TrainingStore.Infrastructure.Repositories;

internal sealed class CourseRepository :
	GenericRepository<Course>,
	ICourseRepository
{
	public CourseRepository(TrainingDbContext dbContext)
		: base(dbContext)
	{
	}

	public async Task<bool> IsDuplicatedName(
		string name,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Course>()
			.AnyAsync(course => course.Name == name, cancellationToken);
	}
}