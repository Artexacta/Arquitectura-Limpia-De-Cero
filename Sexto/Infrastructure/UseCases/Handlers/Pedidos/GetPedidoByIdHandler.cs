using Application.Dto.Pedidos;
using Application.UseCases.Queries.Pedidos;
using Infrastructure.Contexts;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UseCases.Handlers.Pedidos
{
    public class GetPedidoByIdHandler : IRequestHandler<GetPedidoByIdQuery, PedidoDto>
    {
        private readonly DbSet<PedidoDto> _pedidos;

        public GetPedidoByIdHandler(ReadDbContext context)
        {
            _pedidos = context.Pedidos;
        }
        public async Task<PedidoDto> Handle(GetPedidoByIdQuery request, CancellationToken cancellationToken)
        {
            PedidoDto? result = await _pedidos.AsNoTracking()
                .Include(x => x.Detalles)
                .ThenInclude(y => y.Producto)
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (result != null)
            {
                return result;
            }
            return new PedidoDto();
        }
    }
}
