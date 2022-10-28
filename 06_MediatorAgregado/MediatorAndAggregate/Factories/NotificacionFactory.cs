using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Factories
{
    public class NotificacionFactory : INotificacionFactory
    {
        public Notificacion CrearNotificacionVacia()
        {
            return new Notificacion(Guid.Empty, DateTime.MinValue, "", "");
        }

        public Notificacion CrearNueva(Guid id, string mensaje, string email)
        {
            return new Notificacion(id, DateTime.UtcNow, mensaje, email);
        }
    }
}
