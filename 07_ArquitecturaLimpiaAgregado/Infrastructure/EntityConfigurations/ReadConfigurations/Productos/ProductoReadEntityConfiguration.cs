using Application.Dto.Productos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfigurations.ReadConfigurations.Productos
{
    public class ProductoReadEntityConfiguration : IEntityTypeConfiguration<ProductoDto>
    {
        public void Configure(EntityTypeBuilder<ProductoDto> builder)
        {
            builder.ToTable("Productos");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nombre)
                .HasMaxLength(250);

            builder.Property(x => x.Precio)
                .HasColumnType("decimal(18,4)");

            builder.Property(x => x.Stock)
                .HasColumnType("int");
        }
    }
}
