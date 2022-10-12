using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class UpdateItemCommand : IRequest<bool>
    {
        public Guid IdPedido { get; set; }
        public Guid IdProducto { get; set; }
        public int Cantidad { get; set; }

        public UpdateItemCommand(Guid id, Guid idProducto, int cantidad)
        {
            IdPedido = id;
            IdProducto = idProducto;
            Cantidad = cantidad;
        }
    }
}
