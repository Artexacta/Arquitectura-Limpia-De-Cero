using Domain.Models.Productos;

namespace Domain.Factories.Productos
{
    public class ProductoFactory : IProductoFactory
    {
        public ProductoFactory()
        {

        }

        public Producto Create(Guid id, string nombre, decimal precio, int stock)
        {
            Producto producto = new Producto();
            producto.Id = id;
            producto.Nombre = nombre;
            producto.Precio = precio;
            producto.Stock = stock;
            return producto;
        }
    }
}
