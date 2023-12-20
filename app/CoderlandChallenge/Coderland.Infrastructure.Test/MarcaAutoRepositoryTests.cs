using Coderland.Domain.Entities;
using Coderland.Infrastructure.Persistence;
using Coderland.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Coderland.Infrastructure.Test
{
	public class MarcaAutoRepositoryTests
	{
		[Fact]
		public async Task GetProductsBy_Ok()
		{
			// Arrange
			var options = new DbContextOptionsBuilder<CoderlandDBContext>()
				.UseInMemoryDatabase(databaseName: "TestDatabaseForGetProductsBy")
				.Options;

			// Act
			using (var context = new CoderlandDBContext(options))
			{
				context.MarcasAutos.AddRange(
					new MarcaAuto { Id = 10, Nombre = "Toyota2", PaisOrigen = "Japon", EstaActivo = true },
					new MarcaAuto { Id = 11, Nombre = "Chevrolet2", PaisOrigen = "Estados Unidos", EstaActivo = true },
					new MarcaAuto { Id = 20, Nombre = "Lotus2", PaisOrigen = "Reino Unido", EstaActivo = true }
				);
				await context.SaveChangesAsync();
			}

			// Crea un nuevo contexto para el repositorio
			using (var context = new CoderlandDBContext(options))
			{
				var repository = new MarcaAutoRepository(context);
				var products = (repository.GetMarcaAutoBy(q => q.Id == 1)).ToList();

				products.Should().NotBeNull();
				products.Count.Should().Be(1);
			}
		}
	}
}