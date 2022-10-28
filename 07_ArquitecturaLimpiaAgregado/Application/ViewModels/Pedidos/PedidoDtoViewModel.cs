using Application.Dto.Pedidos;
using Domain.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Pedidos
{
    public class PedidoDtoViewModel
    {
        public Guid Id { get; set; }
        public String NombreCliente { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public EstadoPedido Estado { get; set; }
        public List<PedidoItemDtoViewModel> Detalles { get; set; }

        public PedidoDtoViewModel()
        {
            Detalles = new List<PedidoItemDtoViewModel>();
            NombreCliente = "";
            Estado = EstadoPedido.Pendiente;
        }
    }
}
