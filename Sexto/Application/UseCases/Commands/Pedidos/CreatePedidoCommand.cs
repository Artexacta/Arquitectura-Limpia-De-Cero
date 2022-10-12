using MediatR;

namespace Application.UseCases.Commands.Pedidos
{
    public class CreatePedidoCommand : IRequest<Guid>
    {   
        public DateTime Fecha { get; set; }
        
        public CreatePedidoCommand(DateTime f)
        {
            this.Fecha = f;
        }
    }
}
