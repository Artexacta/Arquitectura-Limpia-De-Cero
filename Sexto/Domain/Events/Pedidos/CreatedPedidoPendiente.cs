using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record CreatedPedidoPendiente : DomainEvent
    {
        public Guid PedidoId { get; set; }
        public CreatedPedidoPendiente(Guid id) : base(DateTime.UtcNow)
        {
            PedidoId = id;
        }
    }
}
