namespace Application.Dto.Productos
{
    public class ProductoDto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public decimal Precio { get; set; }

        public ProductoDto()
        {
            Id = Guid.Empty;
            Nombre = "";
            Stock = 0;
            Precio = 0;
        }
    }
}
