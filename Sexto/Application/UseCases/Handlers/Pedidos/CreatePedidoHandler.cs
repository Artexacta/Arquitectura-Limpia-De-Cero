using Application.UseCases.Commands.Pedidos;
using Domain.Events.Pedidos;
using Domain.Factories.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class CreatePedidoHandler : IRequestHandler<CreatePedidoCommand, Guid>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IPedidoFactory _pedidoFactory;
        private readonly IUnitOfWork _unitOfWork;
        public CreatePedidoHandler(IPedidoRepository pedidoRepository,
            IUnitOfWork unitOfWork,
            IPedidoFactory pedidoFactory)
        {
            _pedidoRepository = pedidoRepository;
            _unitOfWork = unitOfWork;
            _pedidoFactory = pedidoFactory;
        }

        public async Task<Guid> Handle(CreatePedidoCommand request, CancellationToken cancellationToken)
        {
            Pedido nuevoPedido = _pedidoFactory.CreatePedido();
            await _pedidoRepository.CreateAsync(nuevoPedido);

            CreatedPedidoPendiente evento = new CreatedPedidoPendiente(nuevoPedido.Id);
            nuevoPedido.AddDomainEvent(evento);

            await _unitOfWork.Commit();
            return nuevoPedido.Id;
        }
    }
}
