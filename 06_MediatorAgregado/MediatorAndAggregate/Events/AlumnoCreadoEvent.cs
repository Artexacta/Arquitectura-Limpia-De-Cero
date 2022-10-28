using SharedKernel.Core;

namespace MediatorAndAggregate.Events
{
    public record AlumnoCreadoEvent : DomainEvent
    {
        public Guid AlumnoId { get; set; }
        public string Nombre { get; set; }
        public AlumnoCreadoEvent(Guid id, string nombre) : base(DateTime.UtcNow)
        {
            AlumnoId = id;
            Nombre = nombre;
        }
    }
}
