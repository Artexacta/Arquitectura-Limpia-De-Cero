using Domain.Events.Pedidos;
using Domain.Models.Pedidos;
using Domain.Models.Productos;
using Domain.Repositories.Pedidos;
using Domain.Repositories.Productos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Consumers.Pedidos
{
    public class ConfirmedPedidoConsumer : INotificationHandler<ConfirmedPedido>
    {
        private readonly IProductoRepository _productoRepository;
        
        public ConfirmedPedidoConsumer(IProductoRepository productoRepository)
        {
            _productoRepository = productoRepository;
        }        

        public async Task Handle(ConfirmedPedido notification, CancellationToken cancellationToken)
        {
            foreach(PedidoItem item in notification.Pedido.Detalles)
            {
                Producto producto = await _productoRepository.FindById(item.ProductoId);
                producto.DescontarStock(item.Cantidad);
                await _productoRepository.UpdateAsync(producto);
            }            
        }
    }
}
