using Microsoft.EntityFrameworkCore;
using Tercero.Domain.Persistence;
using Tercero.Exceptions;
using Tercero.Infrastructure.DbContexts;
using Tercero.Models;

namespace Tercero.Infrastructure.Persistence
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Delete(Guid id)
        {
            Producto? obj = _context.Productos.FirstOrDefault(p => p.Id.Equals(id));
            if (obj != null)
            {
                _context.Productos.Remove(obj);
            }
        }

        public async Task<Producto> GetProductoById(Guid id)
        {
            Producto? obj = await _context.Productos.AsNoTracking().FirstOrDefaultAsync(o => o.Id.Equals(id));
            if (obj != null)
            {
                return obj;
            }
            throw new ProductoException($"No existe objeto con id {id}");
        }

        public List<Producto> GetProductos(string query)
        {
            var queryEf = _context.Productos.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query))
            {
                queryEf = queryEf.Where(o => o.Nombre.Contains(query));
            }

            List<Producto> lista = queryEf.ToList();
            return lista;
        }

        public async Task<Guid> Insert(Producto producto)
        {
            producto.Id = Guid.NewGuid();
            await _context.Productos.AddAsync(producto);
            return producto.Id;
        }

        public void Update(Producto producto)
        {
            Producto? actualizar = _context.Productos.Find(producto.Id);
            if (actualizar == null)
                return;

            actualizar.Nombre = producto.Nombre;
            actualizar.Precio = producto.Precio;
            actualizar.FechaVencimiento = producto.FechaVencimiento;
            actualizar.Cantidad = producto.Cantidad;
            actualizar.Estado = producto.Estado;
        }
    }
}

