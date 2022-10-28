using Domain.Models.Pedidos;
using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record ConfirmedPedido : DomainEvent 
    {
        public Pedido Pedido { get; set; }
        public ConfirmedPedido(Pedido pedido) : base(DateTime.UtcNow)
        {
            Pedido = pedido;
        }
    }
}
