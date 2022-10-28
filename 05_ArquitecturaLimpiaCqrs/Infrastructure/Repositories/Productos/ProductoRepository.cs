using Domain.Models.Productos;
using Domain.Repositories.Productos;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Productos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbSet<Producto> productos;

        public ProductoRepository(WriteDbContext dbContext)
        {
            this.productos = dbContext.Productos;
        }

        public async Task CreateAsync(Producto o)
        {
            await productos.AddAsync(o);
        }

        public async Task DeleteAsync(Producto p)
        {
            productos.Remove(p);
            await Task.CompletedTask;
        }

        public async Task<Producto> FindByIdAsync(Guid id)
        {
            return await productos.SingleAsync(x => x.Id.Equals(id));
        }

        public async Task UpdateAsync(Producto p)
        {
            productos.Update(p);
            await Task.CompletedTask;
        }
    }
}
