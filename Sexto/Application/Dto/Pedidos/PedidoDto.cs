using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dto.Pedidos
{
    public class PedidoDto
    {
        public Guid Id { get; set; }
        public String NombreCliente { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoItemDto> Detalles { get; set; }

        public PedidoDto()
        {
            Detalles = new List<PedidoItemDto>();
            NombreCliente = "";
        }
    }
}
