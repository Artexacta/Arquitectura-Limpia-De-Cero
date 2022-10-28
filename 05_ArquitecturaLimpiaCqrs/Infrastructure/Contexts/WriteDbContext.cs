using Domain.Models.Productos;
using Infrastructure.EntityConfigurations.WriteConfigurations.Productos;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class WriteDbContext : DbContext
    {
        public virtual DbSet<Producto> Productos { get; set; }

        public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var productoConfig = new ProductoWriteEntityConfiguration();
            modelBuilder.ApplyConfiguration<Producto>(productoConfig);
        }
    }
}
