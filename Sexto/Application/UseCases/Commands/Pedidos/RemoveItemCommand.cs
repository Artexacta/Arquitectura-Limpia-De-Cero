using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class RemoveItemCommand : IRequest<bool>
    {
        public Guid IdPedido { get; set; }
        public Guid IdProducto { get; set; }

        public RemoveItemCommand(Guid idPedido, Guid idProducto)
        {
            IdPedido = idPedido;
            IdProducto = idProducto;
        }
    }
}
