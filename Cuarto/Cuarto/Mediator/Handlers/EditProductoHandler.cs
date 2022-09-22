using AutoMapper;
using Cuarto.Domain.Persistence;
using Cuarto.Domain.UnitOfWorkPattern;
using Cuarto.Mediator.Commands;
using Cuarto.Models;
using Cuarto.ViewModels;
using MediatR;

namespace Cuarto.Mediator.Handlers
{
    public class EditProductoHandler : IRequestHandler<EditProductoCommand, ProductoViewModel>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EditProductoHandler(IMapper mapper, 
            IUnitOfWork unitOfWork, 
            IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }

        public async Task<ProductoViewModel> Handle(EditProductoCommand request, CancellationToken cancellationToken)
        {
            Producto aEditar = _mapper.Map<Producto>(request.ProductoEditar);
            Producto? editado = _productoRepository.Update(aEditar);
            if (editado == null)
            {
                // error
                return null;
            }
            else
            {
                await _unitOfWork.Commit();
            }
            return _mapper.Map<ProductoViewModel>(editado);
        }
    }
}
