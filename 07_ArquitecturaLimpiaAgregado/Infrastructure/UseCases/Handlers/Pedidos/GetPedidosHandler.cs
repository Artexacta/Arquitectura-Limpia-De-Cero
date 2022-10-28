using Application.Dto.Pedidos;
using Application.UseCases.Queries.Pedidos;
using Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UseCases.Handlers.Pedidos
{
    public class GetPedidosHandler : IRequestHandler<GetPedidosQuery, List<PedidoDto>>
    {
        private readonly DbSet<PedidoDto> pedidos;
        public GetPedidosHandler(ReadDbContext readDb)
            => pedidos = readDb.Pedidos;
        public async Task<List<PedidoDto>> Handle(GetPedidosQuery request, CancellationToken cancellationToken)
            => await pedidos.AsNoTracking().ToListAsync();
    }
}
