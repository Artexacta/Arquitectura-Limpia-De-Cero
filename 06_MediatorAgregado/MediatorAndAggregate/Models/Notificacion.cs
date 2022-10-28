using MediatorAndAggregate.Events;
using SharedKernel.Core;

namespace MediatorAndAggregate.Models
{
    public class Notificacion : AggregateRoot<Guid>
    {
        public DateTime Creado { get; set; }
        public string Mensaje { get; set; }
        public string Email { get; set; }

        public Notificacion(Guid id, DateTime creado, string mensaje, string email)
        {
            Id = id;
            Creado = creado;
            Mensaje = mensaje;
            Email = email;
        }

        public void ConsolidarCreada()
        {
            AddDomainEvent(new NotificacionCreadaEvent(Id));
        }
    }
}
