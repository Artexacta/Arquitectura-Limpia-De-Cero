using MediatorAndAggregate.Models;
using MediatR;

namespace MediatorAndAggregate.UseCases.Queries
{
    public class FindRegistradosEnMateriaQuery : IRequest<List<Registrado>>
    {
        public Guid MateriaId { get; set; }
        public FindRegistradosEnMateriaQuery(Guid materiaId)
        {
            MateriaId = materiaId;
        }
    }
}
