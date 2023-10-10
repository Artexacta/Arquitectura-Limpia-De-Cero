using SharedKernel.Core;

namespace Domain.Events
{
    public record EstadisticaMateriaActualizadaEvent : DomainEvent
    {
        public Guid MateriaId { get; init; }
        public int CantidadAlumnos { get; init; }

        public EstadisticaMateriaActualizadaEvent(Guid materiaId, int cantidadAlumnos) : base(DateTime.UtcNow)
        {
            MateriaId = materiaId;
            CantidadAlumnos = cantidadAlumnos;
        }
    }
}
