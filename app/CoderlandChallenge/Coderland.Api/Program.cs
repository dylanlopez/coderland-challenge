using Coderland.Api.HealthChecks;
using Coderland.Application;
using Coderland.Infrastructure;

namespace Coderland.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			ConfigurationManager configuration = builder.Configuration;

			// Add services to the container.

			builder.Services.AddApplication();
			builder.Services.AddInfrastructure(configuration);
			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			builder.Services.AddHealthChecks()
				.AddCheck<CoderlandHealthCheck>("MyHealth");

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			app.MapControllers();

			app.MapHealthChecks("/health");

			app.Run();
		}
	}
}
