using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TrainingStore.Infrastructure.Data;

public class AuditFieldInterceptor : SaveChangesInterceptor
{
	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
	{
		SetShadowProperties(eventData);

		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}

	public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
	{
		SetShadowProperties(eventData);

		return base.SavingChanges(eventData, result);
	}

	private static void SetShadowProperties(DbContextEventData eventData)
	{
		var changeTracker = eventData.Context.ChangeTracker;
		DateTime now = DateTime.Now;

		foreach (var entry in changeTracker.Entries())
		{
			if (entry.State == EntityState.Added)
			{
				entry.Property("CreatedBy").CurrentValue = "";
				entry.Property("CreatedDate").CurrentValue = now;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Property("UpdatedBy").CurrentValue = "";
				entry.Property("UpdatedDate").CurrentValue = now;
			}
		}
	}
}