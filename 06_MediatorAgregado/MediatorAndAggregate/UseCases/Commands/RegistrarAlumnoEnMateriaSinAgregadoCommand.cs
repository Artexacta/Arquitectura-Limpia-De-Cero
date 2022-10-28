using MediatR;

namespace MediatorAndAggregate.UseCases.Commands
{
    public class RegistrarAlumnoEnMateriaSinAgregadoCommand : IRequest<bool>
    {
        public Guid AlumnoId { get; set; }
        public Guid MateriaId { get; set; }

        public RegistrarAlumnoEnMateriaSinAgregadoCommand(Guid alumnoId, Guid materiaId)
        {
            AlumnoId = alumnoId;
            MateriaId = materiaId;
        }
    }
}
