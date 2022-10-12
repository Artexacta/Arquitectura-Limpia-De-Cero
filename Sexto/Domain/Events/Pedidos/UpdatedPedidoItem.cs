using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record UpdatedPedidoItem : DomainEvent
    {
        public Guid IdPedido { get; }
        public UpdatedPedidoItem(Guid idPedido) : base(DateTime.Now)
        {
            IdPedido = idPedido;
        }
    }
}
