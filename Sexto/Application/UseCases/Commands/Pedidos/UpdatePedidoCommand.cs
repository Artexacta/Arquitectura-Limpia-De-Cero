using Domain.Models.Shared;
using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class UpdatePedidoCommand : IRequest<bool>
    {
        public Guid IdToUpdate { get; set; }
        public string NombreCliente { get; set; }
        public decimal Descuento { get; set; }

        public UpdatePedidoCommand(Guid id, string cliente, decimal descuento)
        {
            IdToUpdate = id;
            NombreCliente = cliente;
            Descuento = descuento;
        }
    }
}
