using Domain.Models;
using MediatR;

namespace Application.UseCases.Commands
{
    public class RegistrarAlumnoEnMateriaCommand : IRequest<bool>
    {
        public Guid AlumnoId { get; set; }
        public Guid MateriaId { get; set; }
        
        public RegistrarAlumnoEnMateriaCommand(Guid alumnoId, Guid materiaId)
        {
            AlumnoId = alumnoId;
            MateriaId = materiaId;
        }
    }
}
