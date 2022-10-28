using MediatR;

namespace SharedKernel.Core
{
    public abstract record DomainEvent : INotification
    {
        public DateTime OccuredOn { get; }
        public Guid Id { get; }
        public bool Consumed { get; private set; }

        protected DomainEvent(DateTime occuredOn)
        {
            OccuredOn = occuredOn;
            Id = Guid.NewGuid();
            Consumed = false;
        }

        public void Consume()
        {
            Consumed = true;
        }
    }
}