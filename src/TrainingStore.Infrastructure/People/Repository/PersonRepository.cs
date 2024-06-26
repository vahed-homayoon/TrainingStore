﻿using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.People;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.GenericRepository;

namespace TrainingStore.Infrastructure.People.Repository;

internal sealed class PersonRepository :
	GenericRepository<Person>,
	IPersonRepository
{
	public PersonRepository(TrainingDbContext dbContext) :
		base(dbContext)
	{
	}

	public async Task<bool> IsDuplicateNationalCode(
		Guid id,
		string nationalCode,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<Person>()
			.AnyAsync(person => person.Id != id && person.NationalCode == nationalCode, cancellationToken);
	}
}