using MediatR;

namespace Application.UseCases.Commands.Productos
{
    public class CreateProductoCommand : IRequest<Guid>
    {
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public CreateProductoCommand(string nombre, decimal precio, int stock)
        {
            Nombre = nombre;
            Precio = precio;
            Stock = stock;
        }
    }
}
