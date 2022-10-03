using Domain.Models.Productos;
using SharedKernel.Core;

namespace Domain.Repositories.Productos
{
    public interface IProductoRepository : IRepository<Producto, Guid>
    {
        Task UpdateAsync(Producto p);
        Task DeleteAsync(Producto p);
    }
}
