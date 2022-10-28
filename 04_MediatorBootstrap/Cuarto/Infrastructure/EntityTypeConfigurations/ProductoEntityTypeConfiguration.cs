using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cuarto.Models;

namespace Cuarto.Infrastructure.EntityTypeConfigurations
{
    public class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(e => e.Estado)
                .HasConversion(
                    v => v.ToString(),
                    v => (EstadoProducto)Enum.Parse(typeof(EstadoProducto), v))
                .HasMaxLength(50);

        }
    }
}
