namespace Application.Dto.Productos
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ProductoDto()
        {
            Id = Guid.Empty;
            Nombre = string.Empty;
            Precio = 0;
            Stock = 0;
        }

        public ProductoDto(Guid id, string nombre, decimal precio, int stock)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
