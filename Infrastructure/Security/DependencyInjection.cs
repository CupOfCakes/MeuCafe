using System;
using Microsoft.Extensions.DependencyInjection;
using Domain.Security;
using Infrastructure.Security;

namespace Infrastructure.Security;

public static class DependencyInjection
{
	public static IServiceCollection AddSecurity(this IServiceCollection services)
	{
		services.AddScoped<IPasswordHasher, Pbkdf2PasswordHasher>();
		return services;
	}
}
