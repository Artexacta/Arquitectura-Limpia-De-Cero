using Application.Dto.Pedidos;
using MediatR;

namespace Application.UseCases.Queries.Pedidos
{
    public class GetPedidosQuery : IRequest<List<PedidoDto>>
    {
        public GetPedidosQuery() { }
    }
}
