using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class UpdateItemHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateItemHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.FindById(request.IdPedido);
            pedido.UpdateItem(request.IdProducto, request.Cantidad);
            await _pedidoRepository.UpdateAsync(pedido);

            UpdatedPedidoItem domainEvent = new UpdatedPedidoItem(request.IdPedido);
            pedido.AddDomainEvent(domainEvent);

            await _unitOfWork.Commit();
            return true;
        }
    }
}
