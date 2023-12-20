using Coderland.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Coderland.Infrastructure.Persistence.Configurations
{
	public class MarcaAutoConfiguration : IEntityTypeConfiguration<MarcaAuto>
	{
		public void Configure(EntityTypeBuilder<MarcaAuto> builder)
		{
			builder.ToTable("MarcaAuto");

			builder.HasKey(x => x.Id);

			builder.Property(b => b.Id)
				.HasComment("Identificador de la Marca del Auto");

			builder.Property(b => b.Nombre)
				.HasComment("Nombre de la Marca del Auto")
				.HasMaxLength(50);

			builder.Property(b => b.PaisOrigen)
				.HasComment("Pais de Origen de la Marca del Auto")
				.HasMaxLength(200);

			builder.Property(b => b.EstaActivo)
				.HasComment("Determina si la Marca del Auto esta Activo o Inactivo");
		}
	}
}
