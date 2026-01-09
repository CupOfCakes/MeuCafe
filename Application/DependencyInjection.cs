using System;
using Microsoft.Extensions.DependencyInjection;
using Application.UseCases.Clients.List;

namespace Application;

public static class DependencyInjection
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		services.AddScoped<ListClientsUseCase>();
		return services;
	}
}
