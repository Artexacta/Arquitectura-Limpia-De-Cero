using Domain.Models.Productos;
using Domain.Repositories.Shared;

namespace Domain.Repositories.Productos
{
    public interface IProductoRepository : IRepository<Producto, Guid>
    {
        Task UpdateAsync(Producto p);
        Task DeleteAsync(Producto p);
    }
}
