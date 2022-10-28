using Microsoft.EntityFrameworkCore;
using Tercero.Infrastructure.EntityTypeConfigurations;
using Tercero.Models;

namespace Tercero.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        private ILoggerFactory _loggerFactory;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,
            ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }
        public virtual DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ProductoEntityTypeConfiguration());
        }
    }
}
