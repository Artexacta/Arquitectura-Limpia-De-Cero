using Application.Dto.Productos;
using Domain.Models.Productos;
using Infrastructure.EntityConfigurations.ReadConfigurations.Productos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class ReadDbContext : DbContext
    {
        public virtual DbSet<ProductoDto> Productos { get; set; }

        public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var productoConfig = new ProductoReadEntityConfiguration();
            builder.ApplyConfiguration<ProductoDto>(productoConfig);
        }
    }
}
