using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;

namespace Coderland.Application
{
	public static class ApplicationExtensions
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
