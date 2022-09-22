using AutoMapper;
using Cuarto.Domain.Persistence;
using Cuarto.Mediator.Queries;
using Cuarto.Models;
using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Handlers
{
    public class GetProductosHandler : IRequestHandler<GetProductosQuery, List<ProductoViewModel>>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public GetProductosHandler(IProductoRepository productoRepository, 
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProductoViewModel>> Handle(GetProductosQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() =>
            {
                List<Producto> productos = _productoRepository.GetProductos("");
                List<ProductoViewModel> result = new List<ProductoViewModel>();
                foreach (Producto p in productos)
                {
                    result.Add(_mapper.Map<ProductoViewModel>(p));
                }
                return result;
            });
        }
    }
}
