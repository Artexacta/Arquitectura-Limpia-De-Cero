using Domain.Models;
using SharedKernel.Repository;

namespace Domain.Repositories
{
    public interface INotificacionRepository : IRepository<Notificacion,Guid>
    {
    }
}
