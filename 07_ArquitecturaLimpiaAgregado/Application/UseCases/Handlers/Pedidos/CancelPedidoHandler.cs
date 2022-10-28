using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class CancelPedidoHandler : IRequestHandler<CancelPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CancelPedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(CancelPedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.FindById(request.IdToCancel);
            pedido.Cancelar();
            await _pedidoRepository.UpdateAsync(pedido);

            CancelledPedido domainEvent = new CancelledPedido(pedido.Id);
            pedido.AddDomainEvent(domainEvent);

            await _unitOfWork.Commit();
            return true;
        }
    }
}
