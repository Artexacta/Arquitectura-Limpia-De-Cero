using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record AddedPedidoItem : DomainEvent
    {
        public Guid PedidoItemId { get; set; }
        
        public AddedPedidoItem(Guid id) : base(DateTime.UtcNow)
        {
            PedidoItemId = id;
        }
    }
}
