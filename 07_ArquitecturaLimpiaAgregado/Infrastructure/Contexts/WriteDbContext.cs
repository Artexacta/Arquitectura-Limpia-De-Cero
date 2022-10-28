using Domain.Models.Pedidos;
using Domain.Models.Productos;
using Infrastructure.EntityConfigurations.WriteConfigurations.Pedidos;
using Infrastructure.EntityConfigurations.WriteConfigurations.Productos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<PedidoItem> PedidoItems { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var productoConfig = new ProductoWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Producto>(productoConfig);
            var pedidoConfig = new PedidoWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Pedido>(pedidoConfig);
            var pedidoItemConfig = new PedidoItemWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<PedidoItem>(pedidoItemConfig);
        }
    }
}
