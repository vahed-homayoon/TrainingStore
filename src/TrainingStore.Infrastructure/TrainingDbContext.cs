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

		foreach (var item in modelBuilder.Model.GetEntityTypes())
		{
			modelBuilder.Entity(item.ClrType)
				.Property<string>("CreateBy")
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder
				.Entity(item.ClrType)
				.Property<DateTime>("CreateDate")
				.IsRequired();

			modelBuilder
				.Entity(item.ClrType)
				.Property<string?>("UpdateBy")
				.HasMaxLength(50);

			modelBuilder
				.Entity(item.ClrType)
				.Property<DateTime?>("UpdateDate");
		}

		base.OnModelCreating(modelBuilder);
	}
}