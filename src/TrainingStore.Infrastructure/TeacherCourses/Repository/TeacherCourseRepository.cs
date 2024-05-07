using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.People;
using TrainingStore.Domain.TeacherCourses;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.GenericRepository;

namespace TrainingStore.Infrastructure.TeacherCourses.Repository;

internal sealed class TeacherCourseRepository :
	GenericRepository<TeacherCourse>,
	ITeacherCourseRepository
{
	public TeacherCourseRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<dynamic> GetListAsync(CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<TeacherCourse>()
			.Include(p=>p.Teacher)
			.ToListAsync(cancellationToken);
	}
}