using SharedKernel.Core;

namespace MediatorAndAggregate.Events
{
    public record NotificacionCreadaEvent : DomainEvent
    {
        public Guid NotificacionId { get; set; }
        public NotificacionCreadaEvent(Guid notificacionId) : base(DateTime.UtcNow)
        {
            NotificacionId = notificacionId;
        }
    }
}
