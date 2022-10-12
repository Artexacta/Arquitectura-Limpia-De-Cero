using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record ConfirmedPedido : DomainEvent 
    {
        public Guid IdPedido { get; }
        public ConfirmedPedido(Guid idPedido) : base(DateTime.UtcNow)
        {
            IdPedido = idPedido;
        }
    }
}
