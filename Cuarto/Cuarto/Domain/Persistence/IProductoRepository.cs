using Cuarto.Models;

namespace Cuarto.Domain.Persistence
{
    public interface IProductoRepository
    {
        public List<Producto> GetProductos(string query);
        public Task<Producto> GetProductoById(Guid id);
        public Task<Guid> Insert(Producto producto);
        public Producto? Update(Producto producto);
        public void Delete(Guid id);
    }
}
