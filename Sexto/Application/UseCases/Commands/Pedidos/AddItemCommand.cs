using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class AddItemCommand : IRequest<bool>
    {
        public Guid IdPedido { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }

        public AddItemCommand(Guid idPedido, Guid idProducto, int cantidad)
        {
            IdPedido = idPedido;
            IdProducto = idProducto;
            Cantidad = cantidad;
        }
    }
}
