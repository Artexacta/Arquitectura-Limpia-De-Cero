using Domain.Models.Productos;
using Domain.Repositories.Productos;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Productos
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly DbSet<Producto> _productos;

        public ProductoRepository(WriteDbContext context)
        {
            _productos = context.Productos;
        }

        public async Task CreateAsync(Producto obj)
        {
            await _productos.AddAsync(obj);
        }

        public async Task DeleteAsync(Producto p)
        {
            await Task.Run(() => { _productos.Remove(p); });
        }

        public async Task<Producto> FindById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El id no puede ser vacío", nameof(id));

            Producto? resultado = await _productos.FindAsync(id);
            if (resultado == null)
            {
                throw new ArgumentException("No se encontró el Producto con id " + id.ToString());
            }
            return resultado;
        }

        public async Task UpdateAsync(Producto p)
        {
            await Task.Run(() => { _productos.Update(p); });
        }
    }
}
