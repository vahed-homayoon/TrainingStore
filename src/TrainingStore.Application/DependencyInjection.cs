using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shared.MediatR.Behaviors;

namespace TrainingStore.Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddMediatR(configuration =>
		{
			configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

			configuration.AddOpenBehavior(typeof(ValidationBehavior<,>));
		});

		services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);

		return services;
	}
}