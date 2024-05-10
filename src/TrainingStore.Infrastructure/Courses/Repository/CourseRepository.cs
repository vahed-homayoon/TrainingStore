using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Courses;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.GenericRepository;

namespace TrainingStore.Infrastructure.Courses.Repository;

internal sealed class CourseRepository :
	GenericRepository<Course>,
	ICourseRepository
{
	public CourseRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<bool> IsDuplicateName(
		Guid id,
		string name,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Course>()
			.AnyAsync(course => course.Id != id && course.Name == name, cancellationToken);
	}
}