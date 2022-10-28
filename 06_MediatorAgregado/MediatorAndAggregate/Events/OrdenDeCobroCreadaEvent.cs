using SharedKernel.Core;

namespace MediatorAndAggregate.Events
{
    public record OrdenDeCobroCreadaEvent : DomainEvent
    {
        public OrdenDeCobroCreadaEvent(Guid materiaId, Guid alumnoId, decimal monto) : base(DateTime.UtcNow)
        {
            MateriaId = materiaId;
            AlumnoId = alumnoId;
            Monto = monto;
        }
        public Guid MateriaId { get; }
        public Guid AlumnoId { get; }
        public decimal Monto { get; }
    }
}
