using SharedKernel.Core;

namespace Domain.Models.Productos
{
    public class Producto : AggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }
        
        public Producto()
        {
            Nombre = "";
            Stock = 0;
            Precio = 0;
        }
    }
}
