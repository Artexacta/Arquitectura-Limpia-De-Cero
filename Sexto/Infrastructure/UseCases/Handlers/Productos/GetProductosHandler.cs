using Application.Dto.Productos;
using Application.UseCases.Queries.Productos;
using Infrastructure.Contexts;
using MediatR;

namespace Infrastructure.UseCases.Handlers.Productos
{
    public class GetProductosHandler : IRequestHandler<GetProductosQuery, List<ProductoDto>>
    {
        private readonly ReadDbContext _readDb;
        public GetProductosHandler(ReadDbContext readDb)
        {
            _readDb = readDb;
        }

        public async Task<List<ProductoDto>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            List<ProductoDto> productos = await Task.Run(() => {
                return _readDb.Productos.ToList();
            });
            return productos;
        }
    }
}
