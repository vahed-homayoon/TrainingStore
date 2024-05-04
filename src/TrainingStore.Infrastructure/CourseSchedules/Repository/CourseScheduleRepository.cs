using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.CourseSchedules;
using TrainingStore.Domain.People;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.Repository;

namespace TrainingStore.Infrastructure.CourseSchedules.Repository;

internal sealed class CourseScheduleRepository :
	GenericRepository<CourseSchedule>,
	ICourseScheduleRepository
{
	public CourseScheduleRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<bool> IsDuplicateName(
		int id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Person>()
			.AnyAsync(person => person.Id != id && person.NationalCode == nationalCode, cancellationToken);
	}
}