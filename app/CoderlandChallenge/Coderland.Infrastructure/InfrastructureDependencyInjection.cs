using Coderland.Application.Interfaces.Repositories;
using Coderland.Infrastructure.Persistence;
using Coderland.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Coderland.Infrastructure
{
	public static class InfrastructureExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration Configuration)
		{
			var connectionSetting = Configuration.GetSection("ConnectionStrings");
			var v2 = Configuration.GetConnectionString("CoderlandDB");

			services.AddDbContext<CoderlandDBContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("CoderlandDB"))
			);

			//services.AddScoped<CoderlandDBContext>(pro => pro.GetService<CoderlandDBContext>());

			//Repositories
			services.AddTransient<IMarcaAutoRepository, MarcaAutoRepository>();

			return services;
		}
	}
}
