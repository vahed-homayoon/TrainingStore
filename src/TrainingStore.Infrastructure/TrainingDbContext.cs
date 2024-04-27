using Microsoft.EntityFrameworkCore;
using Shared.DbContexts;

namespace TrainingStore.Infrastructure;

public sealed class TrainingDbContext : DbContext, IUnitOfWork
{
    public TrainingDbContext(
    DbContextOptions options)
    : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TrainingDbContext).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}