using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Queries
{
    public class GetProductosQuery : IRequest<List<ProductoViewModel>>
    {
    }
}
