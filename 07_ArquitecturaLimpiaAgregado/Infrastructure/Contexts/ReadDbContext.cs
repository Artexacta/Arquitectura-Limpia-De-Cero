using Application.Dto.Pedidos;
using Application.Dto.Productos;
using Infrastructure.EntityConfigurations.ReadConfigurations.Pedidos;
using Infrastructure.EntityConfigurations.ReadConfigurations.Productos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<ProductoDto> Productos { get; set; }
        public virtual DbSet<PedidoDto> Pedidos { get; set; }
        public virtual DbSet<PedidoItemDto> PedidoItems { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var productoConfig = new ProductoReadEntityConfiguration();
            builder.ApplyConfiguration<ProductoDto>(productoConfig);

            var pedidoConfig = new PedidoReadEntityConfiguration();
            builder.ApplyConfiguration<PedidoDto>(pedidoConfig);

            var pedidoItemConfig = new PedidoItemReadEntityConfiguration();
            builder.ApplyConfiguration<PedidoItemDto>(pedidoItemConfig);
        }
    }
}
