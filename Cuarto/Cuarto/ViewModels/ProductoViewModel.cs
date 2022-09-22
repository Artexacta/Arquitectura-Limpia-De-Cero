using Cuarto.Models;

namespace Cuarto.ViewModels
{
    public class ProductoViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Cantidad { get; set; }
        public EstadoProducto Estado { get; set; }

        public ProductoViewModel()
        {
            Id = Guid.Empty; 
            Nombre = string.Empty;
            Estado = EstadoProducto.Inactivo;
        }
    }
}
