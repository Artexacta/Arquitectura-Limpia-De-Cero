using AutoMapper;
using Cuarto.Domain.Persistence;
using Cuarto.Mediator.Queries;
using Cuarto.Models;
using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Handlers
{
    public class GetProductoByIdHandler : IRequestHandler<GetProductoByIdQuery, ProductoViewModel>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMapper _mapper;
        public GetProductoByIdHandler(IProductoRepository productoRepository, 
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _mapper = mapper;
        }

        public async Task<ProductoViewModel> Handle(GetProductoByIdQuery request, CancellationToken cancellationToken)
        {
            Producto p = await _productoRepository.GetProductoById(request.Id);
            if (p == null)
                throw new ArgumentException("No existe ese producto");
            return _mapper.Map<ProductoViewModel>(p);
        }
    }
}
