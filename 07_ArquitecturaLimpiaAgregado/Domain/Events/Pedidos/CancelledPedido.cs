using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record CancelledPedido : DomainEvent
    {
        public Guid IdPedido { get; }
        public CancelledPedido(Guid idPedido) : base(DateTime.UtcNow)
        {
            IdPedido = idPedido;
        }
    }
}
