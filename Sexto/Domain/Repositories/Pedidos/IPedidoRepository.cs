using Domain.Models.Pedidos;
using SharedKernel.Core;

namespace Domain.Repositories.Pedidos
{
    public interface IPedidoRepository : IRepository<Pedido, Guid>
    {
        Task UpdateAsync(Pedido p);
        Task DeleteAsync(Pedido p);
    }
}
