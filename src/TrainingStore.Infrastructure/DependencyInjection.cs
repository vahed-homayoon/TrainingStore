using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Data;
using Shared.DbContexts;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.Teachers;
using TrainingStore.Infrastructure.Courses.Repository;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.Interceptors;
using TrainingStore.Infrastructure.Students.Repository;
using TrainingStore.Infrastructure.Teachers.Repository;

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

		services.AddDbContext<TrainingDbContext>(options => options
					.UseSqlServer(connectionString)
					.AddInterceptors(new AuditFieldInterceptor()));

		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<ITeacherRepository, TeacherRepository>();
		services.AddScoped<IStudentRepository, StudentRepository>();

		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TrainingDbContext>());

		services.AddSingleton<ISqlConnectionFactory>(_ =>
			new SqlConnectionFactory(connectionString));
	}
}