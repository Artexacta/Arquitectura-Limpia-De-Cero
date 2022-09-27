using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Productos
{
    public class ProductoDtoViewModel
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }

        public ProductoDtoViewModel()
        {
            Id = Guid.Empty;
            Nombre = string.Empty;
            Precio = 0;
        }
    }
}
