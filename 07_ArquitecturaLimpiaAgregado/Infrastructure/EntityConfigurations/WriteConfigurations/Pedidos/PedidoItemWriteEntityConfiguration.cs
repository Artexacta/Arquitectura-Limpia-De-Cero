using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Models.Pedidos;

namespace Infrastructure.EntityConfigurations.WriteConfigurations.Pedidos
{
    public class PedidoItemWriteEntityConfiguration : IEntityTypeConfiguration<PedidoItem>
    {
        public void Configure(EntityTypeBuilder<PedidoItem> builder)
        {
            builder.ToTable("PedidoItems");
            builder.HasKey(x => x.Id);

            builder.Ignore(x => x.DomainEvents);
        }
    }
}
