namespace Cuarto.Models
{
    public enum EstadoProducto
    {
        Activo, Inactivo
    }

    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public int Cantidad { get; set; }
        public EstadoProducto Estado { get; set; }

        public Producto()
        {
            Id = Guid.Empty;
            Nombre = string.Empty;
            Estado = EstadoProducto.Inactivo;
        }
    }
}
