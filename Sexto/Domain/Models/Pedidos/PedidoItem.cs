using SharedKernel.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Pedidos
{
    public class PedidoItem : Entity<Guid>
    {
        public Guid PedidoId { get; set; }
        public Guid ProductoId { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Total
        {
            get { return Cantidad * PrecioUnitario; }
        }
    }
}
