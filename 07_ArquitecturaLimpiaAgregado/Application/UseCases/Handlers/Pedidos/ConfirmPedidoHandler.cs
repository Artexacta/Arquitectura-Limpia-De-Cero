using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Handlers.Pedidos
{
    public class ConfirmPedidoHandler : IRequestHandler<ConfirmPedidoCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ConfirmPedidoHandler(IPedidoRepository pedidoRepository, IUnitOfWork unitOfWork)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> Handle(ConfirmPedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido pedido = await _pedidoRepository.FindById(request.IdToConfirm);
            pedido.Confirmar();
            await _pedidoRepository.UpdateAsync(pedido);

            ConfirmedPedido domainEvent = new ConfirmedPedido(pedido);
            pedido.AddDomainEvent(domainEvent);

            await _unitOfWork.Commit();
            return true;
        }
    }
}
