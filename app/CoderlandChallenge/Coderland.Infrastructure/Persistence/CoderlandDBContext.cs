using Coderland.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Coderland.Infrastructure.Persistence
{
	public class CoderlandDBContext : DbContext
	{
		public virtual DbSet<MarcaAuto> MarcasAutos { get; set; }

		public CoderlandDBContext(DbContextOptions<CoderlandDBContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var brand1 = new MarcaAuto() { Id = 1, Nombre = "Toyota", PaisOrigen = "Japon", EstaActivo = true };
			var brand2 = new MarcaAuto() { Id = 2, Nombre = "Chevrolet", PaisOrigen = "Estados Unidos", EstaActivo = true };
			var brand3 = new MarcaAuto() { Id = 3, Nombre = "Lotus", PaisOrigen = "Reino Unido", EstaActivo = true };

			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

			modelBuilder.Entity<MarcaAuto>().HasData(brand1, brand2, brand3);

			base.OnModelCreating(modelBuilder);
		}
	}
}
