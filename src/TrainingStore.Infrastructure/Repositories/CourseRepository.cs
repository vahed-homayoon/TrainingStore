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

	public async Task<IReadOnlyList<Course>> GetCourseListAsync(CancellationToken cancellationToken = default)
	{
		var result = DbContext
			.Set<Course>();
			//.AsNoTracking();

		int course = result.Count();


		var hh = await result.ToListAsync(cancellationToken);


		return hh;
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