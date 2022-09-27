using Application.UseCases.Commands.Productos;
using Application.UseCases.Queries;
using Application.ViewModels.Productos;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Quinto.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ProductoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<ProductoDtoViewModel> modelo = 
                await _mediator.Send(new GetProductosQuery());
            return View(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(Guid modalEliminarId)
        {
            bool res = await _mediator.Send(new RemoveProductoCommand(modalEliminarId));
            if (!res)
            {

            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Insert(ProductoDtoViewModel modelo)
        {
            CreateProductoCommand cmd = new CreateProductoCommand(modelo.Nombre, modelo.Precio, 0);
            await _mediator.Send(cmd);

            return RedirectToAction(nameof(Index));
        }
    }
}
