using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Queries
{
    public class GetProductoByIdQuery : IRequest<ProductoViewModel>
    {
        public Guid Id { get; set; }
        public GetProductoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
