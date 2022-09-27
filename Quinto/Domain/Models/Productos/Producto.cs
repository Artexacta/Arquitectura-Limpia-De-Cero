using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Productos
{
    public class Producto
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public Producto() 
        {
            Id = Guid.Empty;
            Nombre = "";
            Precio = 0;
            Stock = 0;
        }

    }
}
