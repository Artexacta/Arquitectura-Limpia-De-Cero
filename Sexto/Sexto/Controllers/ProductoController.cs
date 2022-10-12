using Application.Dto.Productos;
using Application.UseCases.Commands.Productos;
using Application.UseCases.Queries.Productos;
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
            List<ProductoDto> productos = 
                await _mediator.Send(new GetProductosQuery());

            List<ProductoDtoViewModel> modelo = new List<ProductoDtoViewModel>();
            foreach(ProductoDto producto in productos)
            {
                modelo.Add(_mapper.Map<ProductoDtoViewModel>(producto));
            }
            return View(modelo);
        }

        [HttpGet]
        public async Task<IActionResult> Eliminar(Guid modalEliminarId)
        {
            await _mediator.Send(new RemoveProductoCommand(modalEliminarId));
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
