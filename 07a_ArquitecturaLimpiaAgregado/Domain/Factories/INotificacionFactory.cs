using Domain.Models;

namespace Domain.Factories
{
    public interface INotificacionFactory 
    {
        Notificacion CrearNotificacionVacia();
        Notificacion CrearNueva(Guid id, string mensaje, string email);
    }
}
