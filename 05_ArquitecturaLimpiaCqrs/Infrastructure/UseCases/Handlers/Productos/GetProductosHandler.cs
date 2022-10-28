using Application.Dto.Productos;
using Application.UseCases.Queries;
using Application.ViewModels.Productos;
using AutoMapper;
using Domain.Repositories.Productos;
using Infrastructure.Contexts;
using MediatR;

namespace Infrastructure.UseCases.Handlers.Productos
{
    public class GetProductosHandler : IRequestHandler<GetProductosQuery, List<ProductoDtoViewModel>>
    {
        private readonly ReadDbContext _readDb;
        private readonly IMapper _mapper;
        public GetProductosHandler(ReadDbContext readDb, 
            IMapper mapper)
        {
            _readDb = readDb;
            _mapper = mapper;
        }

        public async Task<List<ProductoDtoViewModel>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            List<ProductoDtoViewModel> modelo = new List<ProductoDtoViewModel>();

            List<ProductoDto> productos = await Task.Run(() => {
                return _readDb.Productos.ToList();
            });

            foreach(ProductoDto producto in productos)
            {
                modelo.Add(_mapper.Map<ProductoDtoViewModel>(producto));
            }

            return modelo;
        }
    }
}
