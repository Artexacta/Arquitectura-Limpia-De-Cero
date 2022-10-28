using Tercero.Models;

namespace Tercero.Domain.Persistence
{
    public interface IProductoRepository
    {
        public List<Producto> GetProductos(string query);
        public Task<Producto> GetProductoById(Guid id);
        public Task<Guid> Insert(Producto producto);
        public void Update(Producto producto);
        public void Delete(Guid id);
    }
}
