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
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await DbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public virtual void Add(T entity)
    {
        DbContext.Add(entity);
    }
}
