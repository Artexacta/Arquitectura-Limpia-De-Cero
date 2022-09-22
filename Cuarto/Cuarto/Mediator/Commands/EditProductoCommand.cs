using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Commands
{
    public class EditProductoCommand : IRequest<ProductoViewModel>
    {
        public ProductoViewModel ProductoEditar { get; set; }

        public EditProductoCommand(ProductoViewModel productoEditar)
        {
            ProductoEditar = productoEditar;
        }
    }
}
