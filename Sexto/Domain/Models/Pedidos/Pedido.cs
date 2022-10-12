using Domain.Models.Shared;
using SharedKernel.Core;

namespace Domain.Models.Pedidos
{
    public class Pedido : AggregateRoot<Guid>
    {
        public String NombreCliente { get; set; }
        public decimal Descuento { get; set; }
        public DateTime Fecha { get; set; }
        public List<PedidoItem> Detalles { get; set; }
        public EstadoPedido Estado { get; set; }
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
            Id = Guid.NewGuid();
            Detalles = new List<PedidoItem>();
            NombreCliente = "";
        }
        
        public PedidoItem AddItem(Guid idProducto, decimal precio, int cantidad)
        {
            PedidoItem item = new PedidoItem();
            item.ProductoId = idProducto;
            item.PrecioUnitario = precio;
            item.Cantidad = cantidad;
            item.PedidoId = Id;
            
            Detalles.Add(item);

            return item;
        }

        public void RemoveItem(Guid idProducto)
        {
            PedidoItem? item = Detalles.FirstOrDefault(x => x.ProductoId.Equals(idProducto));
            if (item == null)
                return;

            Detalles.Remove(item);
        }

        public void UpdateItem(Guid idProducto, int cantidad)
        {
            PedidoItem? item = Detalles.FirstOrDefault(x => x.ProductoId.Equals(idProducto));
            if (item == null)
                return;

            item.Cantidad = cantidad;            
        }

        public void Confirmar()
        {
            throw new NotImplementedException();
        }
    }
}
