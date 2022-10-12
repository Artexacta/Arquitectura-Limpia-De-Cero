using ShareKernel.Core;

namespace Domain.Events.Pedidos
{
    public record UpdatedPedido : DomainEvent
    {
        public Guid IdPedido { get; }
        public UpdatedPedido(Guid idPedido) : base(DateTime.UtcNow)
        {
            IdPedido = idPedido;
        }        
    }
}
