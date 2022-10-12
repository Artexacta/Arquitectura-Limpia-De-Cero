using Application.Dto.Pedidos;
using Application.UseCases.Commands.Pedidos;
using Application.UseCases.Queries.Pedidos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Sexto.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IMediator _mediator;

        public PedidoController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<JsonResult> Get(Guid id)
        {
            PedidoDto dto = await _mediator.Send(new GetPedidoByIdQuery(id));
            return Json(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Insert()
        {
            Guid nuevo = await _mediator.Send(new CreatePedidoCommand(DateTime.UtcNow));
            return RedirectToAction(nameof(Get), new { id = nuevo });
        }

        [HttpPost]
        public async Task<JsonResult> UpdatePedido(Guid id, string cliente, decimal descuento)
        {
            UpdatePedidoCommand cmd = new UpdatePedidoCommand(id, cliente, descuento);
            await _mediator.Send(cmd);
            return Json(true);
        }

        [HttpPost]
        public async Task<JsonResult> AddItem(PedidoItemDto dto)
        {
            AddItemCommand cmd = new AddItemCommand(dto.PedidoId, dto.ProductoId, dto.Cantidad);
            await _mediator.Send(cmd);
            return Json(true);
        }

        [HttpPost]
        public async Task<JsonResult> RemoveItem(Guid idpedido, Guid idproducto)
        {
            RemoveItemCommand cmd = new RemoveItemCommand(idpedido, idproducto);
            await _mediator.Send(cmd);
            return Json(true);
        }

        [HttpPost]
        public async Task<JsonResult> UpdateItem(Guid id, Guid idproducto, int cantidad)
        {
            UpdateItemCommand cmd = new UpdateItemCommand(id, idproducto, cantidad);
            await _mediator.Send(cmd);
            return Json(true);
        }

        [HttpGet]
        public async Task<JsonResult> ConfirmPedido(Guid id)
        {
            ConfirmPedidoCommand cmd = new ConfirmPedidoCommand(id);
            await _mediator.Send(cmd);
            return Json(true);
        }

        [HttpGet]
        public async Task<JsonResult> CancelPedido(Guid id)
        {
            CancelPedidoCommand cmd = new CancelPedidoCommand(id);
            await _mediator.Send(cmd);
            return Json(true);
        }
    }
}
