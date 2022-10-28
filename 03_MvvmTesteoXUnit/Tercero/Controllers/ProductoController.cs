using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tercero.Domain.Persistence;
using Tercero.Models;
using Tercero.ViewModels;

namespace Tercero.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;

        public ProductoController(IProductoRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<Producto> lista = _repository.GetProductos("");

            List<ProductoViewModel> modelo = new List<ProductoViewModel>();
            foreach(Producto p in lista)
            {
                modelo.Add(_mapper.Map<ProductoViewModel>(p));
            }
            return View(modelo);
        }
    }
}
