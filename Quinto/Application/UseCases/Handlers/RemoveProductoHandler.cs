using Application.UseCases.Commands.Productos;
using Domain.Models.Productos;
using Domain.Repositories.Productos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers
{
    public class RemoveProductoHandler : IRequestHandler<RemoveProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveProductoHandler(IProductoRepository productoRepository, 
            IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveProductoCommand request, CancellationToken cancellationToken)
        {
            Producto p = await _productoRepository.FindByIdAsync(request.IdToRemove);
            await _productoRepository.DeleteAsync(p);
            await _unitOfWork.Commit();
            return true;
        }
    }
}
