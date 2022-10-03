using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Application.Dto.Pedidos;

namespace Infrastructure.EntityConfigurations.ReadConfigurations.Pedidos
{
    public class PedidoItemReadEntityConfiguration : IEntityTypeConfiguration<PedidoItemDto>
    {
        public void Configure(EntityTypeBuilder<PedidoItemDto> builder)
        {
            builder.ToTable("PedidoItems");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.PrecioUnitario)
                .HasColumnType("decimal(18,4)");
            builder.Property(x => x.Total)
                .HasColumnType("decimal(18,4)");
        }
    }
}
