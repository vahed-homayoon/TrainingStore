using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Shared.Data;
using Shared.DbContexts;
using Shared.Email;
using Shared.Outbox;
using TrainingStore.Domain.Courses;
using TrainingStore.Domain.People;
using TrainingStore.Domain.Students;
using TrainingStore.Domain.TeacherCourses;
using TrainingStore.Domain.Teachers;
using TrainingStore.Infrastructure.Courses.Repository;
using TrainingStore.Infrastructure.Data;
using TrainingStore.Infrastructure.Email;
using TrainingStore.Infrastructure.People.Repository;
using TrainingStore.Infrastructure.Students.Repository;
using TrainingStore.Infrastructure.TeacherCourses.Repository;
using TrainingStore.Infrastructure.Teachers.Repository;
using Microsoft.Extensions.Configuration;

namespace TrainingStore.Infrastructure;

public static class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(
		this IServiceCollection services,
		IConfiguration configuration)
	{
		AddPersistence(services, configuration);

		AddEmail(services, configuration);

		AddBackgroundJobs(services, configuration);

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
		services.AddScoped<IPersonRepository, PersonRepository>();
		services.AddScoped<ITeacherCourseRepository, TeacherCourseRepository>();
	
		services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<TrainingDbContext>());

		services.AddSingleton<ISqlConnectionFactory>(_ =>
			new SqlConnectionFactory(connectionString));
	}
	private static void AddBackgroundJobs(IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<OutboxOptions>(configuration.GetSection("Outbox"));

		services.AddQuartz();

		services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

		services.ConfigureOptions<ProcessOutboxMessagesJobSetup>();
	}

	private static void AddEmail(IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient<IEmailService, EmailService>();

		services.Configure<MailSettingOptions>(configuration.GetSection("MailSettings"));
	}
}