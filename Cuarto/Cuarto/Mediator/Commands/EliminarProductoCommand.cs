using MediatR;

namespace Cuarto.Mediator.Commands
{
    public class EliminarProductoCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

        public EliminarProductoCommand(Guid id)
        {
            Id = id;
        }
    }
}
