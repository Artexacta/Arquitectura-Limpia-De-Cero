using Application.ViewModels.Productos;

namespace Application.ViewModels.Pedidos
{
    public class PedidoItemDtoViewModel
    {
        public Guid Id { get; set; }
        public Guid PedidoId { get; set; }
        public ProductoDtoViewModel Producto { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total { get; set; }

        public PedidoItemDtoViewModel()
        {
            Producto = new ProductoDtoViewModel();
        }
    }
}
