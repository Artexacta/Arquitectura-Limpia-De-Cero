using Application.Dtos;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindRegistradosEnMateriaQuery : IRequest<List<RegistradoDto>>
    {
        public Guid MateriaId { get; set; }
        public FindRegistradosEnMateriaQuery(Guid materiaId)
        {
            MateriaId = materiaId;
        }
    }
}
