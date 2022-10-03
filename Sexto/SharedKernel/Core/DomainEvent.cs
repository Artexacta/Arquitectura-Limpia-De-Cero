using MediatR;

namespace ShareKernel.Core
{
    public abstract record DomainEvent : INotification
    {
        public DateTime OccuredOn { get; }
        public Guid Id { get; }

        protected DomainEvent(DateTime occuredOn)
        {
            OccuredOn = occuredOn;
            Id = Guid.NewGuid();
        }
    }
}