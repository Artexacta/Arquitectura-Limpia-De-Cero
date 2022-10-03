using Application.Dto.Productos;

namespace Application.Dto.Pedidos
{
    public class PedidoItemDto
    {
        public Guid Id { get; set; }
        public PedidoDto Pedido { get; set; }
        public Guid PedidoId { get; set; }
        public ProductoDto Producto { get; set; } 
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        public PedidoItemDto()
        {
            Pedido = new PedidoDto();
            Producto = new ProductoDto();
        }
    }
}
