using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class CancelPedidoCommand : IRequest<bool>
    {
        public Guid IdToCancel { get; set; }

        public CancelPedidoCommand(Guid id)
        {
            IdToCancel = id;
        }
    }
}
