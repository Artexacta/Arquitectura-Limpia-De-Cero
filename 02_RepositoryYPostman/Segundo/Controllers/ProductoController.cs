using Microsoft.AspNetCore.Mvc;
using Segundo.Domain.Persistence;
using Segundo.Domain.UnitOfWorkPattern;
using Segundo.Models;

namespace Segundo.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IUnitOfWork unitOfWork;

        public ProductoController(IProductoRepository productoRepository, 
            IUnitOfWork unitOfWork)
        {
            _productoRepository = productoRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get()
        {
            return _productoRepository.GetProductos("");
        }

        [HttpGet(Name ="GetProductoById")]
        public async Task<Producto> GetProductoById(Guid id)
        {
            return await _productoRepository.GetProductoById(id);
        }

        [HttpPost(Name = "InsertProducto")]
        public async Task<Producto> Create(Producto p)
        {
            Guid nuevo = await _productoRepository.Insert(p);
            p.Id = nuevo;
            await unitOfWork.Commit();
            return p;
        }

        [HttpPost(Name = "UpdateProducto")]
        public async Task<Producto> Update(Producto p)
        {
            _productoRepository.Update(p);
            await unitOfWork.Commit();
            return p;
        }

        [HttpPost(Name = "DeleteProducto")]
        public async Task<int> Delete(Guid id)
        {
            _productoRepository.Delete(id);
            await unitOfWork.Commit();
            return 1;
        }
    }
}
