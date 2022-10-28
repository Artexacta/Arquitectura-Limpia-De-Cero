using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record RemovedPedidoItem : DomainEvent
    {
        public Guid IdProducto { get; init; }
        public RemovedPedidoItem(Guid idProducto) : base(DateTime.UtcNow)
        {
            IdProducto = idProducto;
        }
    }
}
