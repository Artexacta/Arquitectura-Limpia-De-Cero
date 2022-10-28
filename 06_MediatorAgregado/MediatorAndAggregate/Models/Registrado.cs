using SharedKernel.Core;

namespace MediatorAndAggregate.Models
{
    public class Registrado : Entity<Guid>
    {
        public Guid AlumnoId { get; set; }
        public Guid MateriaId { get; set; }

        public Registrado(Guid id, Guid alumnoId, Guid materiaId)
        {
            Id = id;
            AlumnoId = alumnoId;
            MateriaId = materiaId;
        }
    }
}
