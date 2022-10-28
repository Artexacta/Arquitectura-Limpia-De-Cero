using Application.Dto.Pedidos;
using MediatR;

namespace Application.UseCases.Queries.Pedidos
{
    public class GetPedidoByIdQuery : IRequest<PedidoDto>
    {
        public Guid Id { get; set; }

        public GetPedidoByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
