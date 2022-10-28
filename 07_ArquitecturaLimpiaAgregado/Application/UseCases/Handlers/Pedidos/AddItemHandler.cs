using Application.Dto.Productos;
using Application.UseCases.Commands.Pedidos;
using Application.UseCases.Queries.Productos;
using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Repositories.Pedidos;
using Domain.UnitOfWorkPattern;
using MediatR;

namespace Application.UseCases.Handlers.Pedidos
{
    public class AddItemHandler : IRequestHandler<AddItemCommand, bool>
    {
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IMediator _mediator;
        private readonly IUnitOfWork _unitOfWork;

        public AddItemHandler(IPedidoRepository pedidoRepository, 
            IMediator mediator)
        {
            _pedidoRepository = pedidoRepository;
            _mediator = mediator;
        }

        public async Task<bool> Handle(AddItemCommand request, CancellationToken cancellationToken)
        {
            GetProductoByIdQuery query = new GetProductoByIdQuery(request.IdProducto);
            ProductoDto producto = await _mediator.Send(query);

            if (request.Cantidad > producto.Stock)
                return false;

            Pedido pedido = await _pedidoRepository.FindById(request.IdPedido);
            PedidoItem item = pedido.AddItem(producto.Id, producto.Precio, request.Cantidad);

            await _pedidoRepository.UpdateAsync(pedido);

            AddedPedidoItem evento = new AddedPedidoItem(item.Id);
            pedido.AddDomainEvent(evento);

            await _unitOfWork.Commit();

            return true;
        }
    }
}
