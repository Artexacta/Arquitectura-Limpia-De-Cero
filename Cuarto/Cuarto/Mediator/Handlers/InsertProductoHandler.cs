using AutoMapper;
using Cuarto.Domain.Persistence;
using Cuarto.Domain.UnitOfWorkPattern;
using Cuarto.Mediator.Commands;
using Cuarto.Models;
using MediatR;

namespace Cuarto.Mediator.Handlers
{
    public class InsertProductoHandler : IRequestHandler<InsertProductoCommand, Guid>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public InsertProductoHandler(IProductoRepository productoRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _productoRepository = productoRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(InsertProductoCommand request, CancellationToken cancellationToken)
        {
            Producto nuevo = _mapper.Map<Producto>(request.NuevoProducto);
            Guid nuevoGuid = await _productoRepository.Insert(nuevo);
            await _unitOfWork.Commit();

            return nuevoGuid;
        }
    }
}
