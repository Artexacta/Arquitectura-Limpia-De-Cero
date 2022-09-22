using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Cuarto.Domain.Persistence;
using Cuarto.Models;
using Cuarto.ViewModels;
using MediatR;
using Cuarto.Mediator.Commands;
using Cuarto.Mediator.Queries;

namespace Cuarto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IProductoRepository _repository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductoController(IProductoRepository repository,
            IMapper mapper,
            IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductoViewModel> modelo = 
                await _mediator.Send(new GetProductosQuery());
            return View(modelo);
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductoViewModel p)
        {
            Guid nuevo = await _mediator.Send(new InsertProductoCommand(p));
            return RedirectToAction(nameof(Edit), new { id = nuevo });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            ProductoViewModel model = 
                await _mediator.Send(new GetProductoByIdQuery(id));
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProductoViewModel p)
        {
            EditProductoCommand cmd = new EditProductoCommand(p);
            ProductoViewModel actualizado = await _mediator.Send(cmd);

            return RedirectToAction(nameof(Edit), new { id = actualizado.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(Guid modalEliminarId)
        {
            EliminarProductoCommand cmd = new EliminarProductoCommand(modalEliminarId);
            bool resultado = await _mediator.Send(cmd);

            if (!resultado)
            {
                // error deleting
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
