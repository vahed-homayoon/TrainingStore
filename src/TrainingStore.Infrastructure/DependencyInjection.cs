﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;
using Shared.DbContexts;
using TrainingStore.Domain.Courses;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.Repositories;

namespace TrainingStore.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        AddPersistence(services, configuration);

        return services;
    }

    private static void AddPersistence(IServiceCollection services, IConfiguration configuration)
    {
        string connectionString = configuration.GetConnectionString("Database") ??
                                  throw new ArgumentNullException(nameof(configuration));

        services.AddDbContext<TrainingDbContext>(options =>
            options.UseSqlServer(connectionString));

        services.AddScoped<ICourseRepository, CourseRepository>();

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TrainingDbContext>());

		services.AddSingleton<ISqlConnectionFactory>(_ =>
			new SqlConnectionFactory(connectionString));
	}
}