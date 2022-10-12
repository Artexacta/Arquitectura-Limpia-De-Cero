using Application.Dto.Productos;
using MediatR;

namespace Application.UseCases.Queries.Productos
{
    public class GetProductoByIdQuery : IRequest<ProductoDto>
    {
        public Guid Id { get; set; }

        public GetProductoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
