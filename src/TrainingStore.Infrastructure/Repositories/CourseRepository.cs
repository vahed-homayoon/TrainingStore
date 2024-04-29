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
		int id,
		string name,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Course>()
			.AnyAsync(course => course.Id != id && course.Name == name, cancellationToken);
	}
}