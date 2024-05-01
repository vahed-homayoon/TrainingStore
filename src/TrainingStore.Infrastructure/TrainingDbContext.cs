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
				.Property<string>("CreatedBy")
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder
				.Entity(item.ClrType)
				.Property<DateTime>("CreatedDate")
				.IsRequired();

			modelBuilder
				.Entity(item.ClrType)
				.Property<string?>("UpdatedBy")
				.HasMaxLength(50);

			modelBuilder
				.Entity(item.ClrType)
				.Property<DateTime?>("UpdatedDate");
		}

		base.OnModelCreating(modelBuilder);
	}
}