using Microsoft.EntityFrameworkCore;
using TrainingStore.Api.Middleware;
using TrainingStore.Infrastructure.Data;

namespace TrainingStore.Api.Extensions;

internal static class ApplicationBuilderExtensions
{
    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        using TrainingDbContext dbContext = scope.ServiceProvider.GetRequiredService<TrainingDbContext>();

        dbContext.Database.Migrate();
    }

    public static void UseCustomExceptionHandler(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
