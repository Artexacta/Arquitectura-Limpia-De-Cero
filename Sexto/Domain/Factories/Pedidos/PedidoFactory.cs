using Domain.Models.Pedidos;

namespace Domain.Factories.Pedidos
{
    public class PedidoFactory : IPedidoFactory
    {
        public PedidoFactory() { }
        public Pedido CreatePedido()
        {
            Pedido result = new Pedido();
            result.Fecha = DateTime.UtcNow;
            result.Estado = Models.Shared.EstadoPedido.Pendiente;
            
            return result;
        }
    }
}
