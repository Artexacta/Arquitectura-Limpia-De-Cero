using Application.ViewModels;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindRegistradosEnMateriaQuery : IRequest<List<RegistradoViewModel>>
    {
        public Guid MateriaId { get; set; }
        public FindRegistradosEnMateriaQuery(Guid materiaId)
        {
            MateriaId = materiaId;
        }
    }
}
