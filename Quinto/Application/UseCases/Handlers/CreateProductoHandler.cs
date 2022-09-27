using Application.UseCases.Commands.Productos;
using Domain.Factories.Productos;
using Domain.Models.Productos;
using Domain.Repositories.Productos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers
{
    public class CreateProductoHandler : IRequestHandler<CreateProductoCommand, Guid>
    {
        private readonly IProductoFactory _productoFactory;
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateProductoHandler(IProductoFactory productoFactory,
            IProductoRepository productoRepository,
            IUnitOfWork unitOfWork)
        {
            _productoFactory = productoFactory;
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Guid> Handle(CreateProductoCommand request, CancellationToken cancellationToken)
        {
            Producto p = _productoFactory.Create(Guid.NewGuid(), request.Nombre, request.Precio, request.Stock);
            await _productoRepository.CreateAsync(p);
            await _unitOfWork.Commit();
            return p.Id;
        }
    }
}
