using Application.Dto.Productos;
using MediatR;

namespace Application.UseCases.Queries.Productos
{
    public class GetProductosQuery : IRequest<List<ProductoDto>>
    {
        public GetProductosQuery() { }
    }
}
