using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Pedidos;
using Domain.Models.Shared;

namespace Infrastructure.EntityConfigurations.WriteConfigurations.Pedidos
{
    public class PedidoWriteEntityConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.ToTable("Pedidos");
            builder.HasKey(x => x.Id);

            builder.Property(e => e.Estado)
                .HasConversion(
                    v => v.ToString(),
                    v => (EstadoPedido)Enum.Parse(typeof(EstadoPedido), v))
                .HasMaxLength(50);

            builder.Ignore(x => x.DomainEvents);
        }
    }
}
