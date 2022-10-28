using ShareKernel.Core;

namespace SharedKernel.Core
{
    public abstract class Entity<TId>
    {
        public TId Id { get; protected set; }

        private readonly ICollection<DomainEvent> _domainEvents;

        public ICollection<DomainEvent> DomainEvents { get { return _domainEvents; } }

        protected Entity()
        {
            _domainEvents = new List<DomainEvent>();
        }

        public void AddDomainEvent(DomainEvent evento)
        {
            _domainEvents.Add(evento);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }
    }
}