using Domain.Models.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Productos
{
    public interface IProductoFactory
    {
        Producto Create(Guid id, string nombre, decimal precio, int stock);
    }
}
