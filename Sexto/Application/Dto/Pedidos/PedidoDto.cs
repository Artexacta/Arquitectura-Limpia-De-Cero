using Domain.Models.Shared;

namespace Application.Dto.Pedidos
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public String NombreCliente { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PedidoItemDto> Detalles { get; set; }

        public PedidoDto()
        {
            Detalles = new List<PedidoItemDto>();
            NombreCliente = "";
            Estado = EstadoPedido.Pendiente;
        }
    }
}
