using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Factories
{
    public interface INotificacionFactory 
    {
        Notificacion CrearNotificacionVacia();
        Notificacion CrearNueva(Guid id, string mensaje, string email);
    }
}
