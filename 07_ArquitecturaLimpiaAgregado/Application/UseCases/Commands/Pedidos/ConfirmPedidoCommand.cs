using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class ConfirmPedidoCommand : IRequest<bool>
    {
        public Guid IdToConfirm { get; set; }

        public ConfirmPedidoCommand(Guid id)
        {
            IdToConfirm = id;
        }
    }
}
