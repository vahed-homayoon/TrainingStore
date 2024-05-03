﻿using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Courses;
using TrainingStore.Infrastructure.Repository;

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
		int id,
		string name,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Course>()
			.AnyAsync(course => course.Id != id && course.Name == name, cancellationToken);
	}
}