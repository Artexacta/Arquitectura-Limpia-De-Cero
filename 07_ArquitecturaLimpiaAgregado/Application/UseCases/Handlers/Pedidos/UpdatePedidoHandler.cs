using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class UpdatePedidoHandler : IRequestHandler<UpdatePedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdatePedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(UpdatePedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.FindById(request.IdToUpdate);
            pedido.Descuento = request.Descuento;
            pedido.NombreCliente = request.NombreCliente;
            await _pedidoRepository.UpdateAsync(pedido);

            UpdatedPedido domainEvent = new UpdatedPedido(pedido.Id);
            pedido.AddDomainEvent(domainEvent);

            await _unitOfWork.Commit();
            return true;
        }
    }
}
