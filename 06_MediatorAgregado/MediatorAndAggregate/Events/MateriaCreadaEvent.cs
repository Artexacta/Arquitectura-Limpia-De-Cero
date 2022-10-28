using SharedKernel.Core;

namespace MediatorAndAggregate.Events
{
    public record MateriaCreadaEvent : DomainEvent
    {
        public MateriaCreadaEvent(Guid id, string nombre) : base(DateTime.UtcNow)
        {
            MateriaId = id;
            Nombre = nombre;
        }

        public Guid MateriaId { get; set; }
        public string Nombre { get; }
    }
}
