using SharedKernel.Core;

namespace MediatorAndAggregate.Events
{
    public record AlumnoRegistradoEvent : DomainEvent
    {
        public AlumnoRegistradoEvent(Guid alumnoId, Guid materiaId, string nombreAlumno, string email) : base(DateTime.UtcNow)
        {
            AlumnoId = alumnoId;
            MateriaId = materiaId;
            NombreAlumno = nombreAlumno;
            Email = email;
        }

        public Guid AlumnoId { get; }
        public string NombreAlumno { get; set; }
        public string Email { get; set; }
        public Guid MateriaId { get; }
    }
}
