using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class RemoveItemHandler : IRequestHandler<RemoveItemCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveItemHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(RemoveItemCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.FindById(request.IdPedido);                        
            pedido.RemoveItem(request.IdProducto);
            await _pedidoRepository.UpdateAsync(pedido);

            RemovedPedidoItem domainEvent = new RemovedPedidoItem(request.IdProducto);
            pedido.AddDomainEvent(domainEvent);

            await _unitOfWork.Commit();
            return true;
        }
    }
}
