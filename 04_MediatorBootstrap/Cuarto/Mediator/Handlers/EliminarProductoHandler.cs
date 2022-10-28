using AutoMapper;
using Cuarto.Domain.Persistence;
using Cuarto.Domain.UnitOfWorkPattern;
using Cuarto.Mediator.Commands;
using MediatR;

namespace Cuarto.Mediator.Handlers
{
    public class EliminarProductoHandler : IRequestHandler<EliminarProductoCommand, bool>
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EliminarProductoHandler(IMapper mapper,
            IUnitOfWork unitOfWork,
            IProductoRepository productoRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _productoRepository = productoRepository;
        }
        public async Task<bool> Handle(EliminarProductoCommand request, CancellationToken cancellationToken)
        {
            _productoRepository.Delete(request.Id);
            await _unitOfWork.Commit();
            return true;
        }
    }
}
