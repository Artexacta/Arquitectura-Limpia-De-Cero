using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories.Pedidos
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly DbSet<Pedido> _pedidos;

        public PedidoRepository(WriteDbContext context)
        {
            _pedidos = context.Pedidos;
        }
        
        public async Task CreateAsync(Pedido obj)
        {
            await _pedidos.AddAsync(obj);
        }

        public async Task DeleteAsync(Pedido p)
        {
            await Task.Run(() => { _pedidos.Remove(p); }); 
        }

        public async Task<Pedido> FindById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ArgumentException("El id no puede ser vacío", nameof(id));
            
            Pedido? resultado = await _pedidos.FindAsync(id);
            if (resultado == null)
            {
                throw new ArgumentException("No se encontró el pedido con id " + id.ToString());
            }
            return resultado;
        }

        public async Task UpdateAsync(Pedido p)
        {
            await Task.Run(() => { _pedidos.Update(p); });
        }
    }
}
