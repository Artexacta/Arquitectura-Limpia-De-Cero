using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Commands
{
    public class InsertProductoCommand : IRequest<Guid>
    {
        public ProductoViewModel NuevoProducto { get; set; }

        public InsertProductoCommand(ProductoViewModel p)
        {
            NuevoProducto = p;
        }
    }
}
