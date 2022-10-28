using MediatorAndAggregate.Models;
using MediatR;

namespace MediatorAndAggregate.UseCases.Commands
{
    public class CreateMateriaCommand : IRequest<bool>
    {
        public CreateMateriaCommand(string materia)
        {
            MateriaACrear = materia;
        }

        public string MateriaACrear { get; }
    }
}
