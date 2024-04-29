using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TrainingStore.Infrastructure.Interceptor;

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
				entry.Property("CreateBy").CurrentValue = "";
				entry.Property("CreateDate").CurrentValue = now;
			}
			else if (entry.State == EntityState.Modified)
			{
				entry.Property("UpdateBy").CurrentValue = "";
				entry.Property("UpdateDate").CurrentValue = now;
			}
		}
	}
}