using Microsoft.EntityFrameworkCore;
using TrainingStore.Domain.Abstractions;

namespace TrainingStore.Infrastructure.Repositories;

internal abstract class GenericRepository<T>
	where T : BaseEntity
{
	protected readonly TrainingDbContext DbContext;

	protected GenericRepository(TrainingDbContext dbContext)
	{
		DbContext = dbContext;
	}

	public async Task<T?> GetByIdAsync(
		int id,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<T>()
			.AsNoTracking()
			.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
	}


	public async Task<T?> FindByIdAsync(
		int id,
		CancellationToken cancellationToken = default)
	{
		return await DbContext
			.Set<T>()
			.FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken);
	}

	public virtual void Add(T entity)
	{
		DbContext.Add(entity);
	}


	public virtual void Delete(T entity)
	{
		DbContext.Remove(entity);
	}
}
