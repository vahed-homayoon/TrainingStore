using Microsoft.EntityFrameworkCore;
using Shared.DbContexts;
using Shared.Entities;

namespace TrainingStore.Infrastructure.Data;

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

		var auditableEntities = modelBuilder.Model
			.GetEntityTypes()
			.Where(e => typeof(IAuditable)
			.IsAssignableFrom(e.ClrType))
			.ToList();

		foreach (var item in auditableEntities)
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