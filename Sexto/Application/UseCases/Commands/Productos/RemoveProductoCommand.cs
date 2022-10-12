using MediatR;

namespace Application.UseCases.Commands.Productos
{
    public class RemoveProductoCommand : IRequest<bool>
    {
        public Guid IdToRemove { get; set; }

        public RemoveProductoCommand(Guid id)
        {
            IdToRemove = id;
        }
    }
}
