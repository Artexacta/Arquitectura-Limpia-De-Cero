using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Pedidos
{
    public class Pedido : AggregateRoot<Guid>
    {
        public String NombreCliente { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoItem> Detalles { get; set; }
        public decimal Subtotal
        {
            get
            {
                decimal subtotal = 0m;
                foreach(PedidoItem item in Detalles)
                {
                    subtotal += (item.Cantidad * item.PrecioUnitario);
                }
                return subtotal;
            }
        }
        public decimal Total
        {
            get
            {
                return Subtotal - Descuento;
            }
        }

        public Pedido() {
            Detalles = new List<PedidoItem>();
            NombreCliente = "";
        }
    }
}
