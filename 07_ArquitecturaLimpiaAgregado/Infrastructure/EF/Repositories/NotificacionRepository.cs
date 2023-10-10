using Domain.Factories;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NotificacionRepository : INotificacionRepository
    {
        private readonly DbSet<Notificacion> Notificaciones;
        private readonly INotificacionFactory factory;

        public NotificacionRepository(WriteDbContext context, 
            INotificacionFactory factory)
        {
            Notificaciones = context.Notificaciones;
            this.factory = factory;
        }

        public async Task CreateAsync(Notificacion obj)
        {
            await Notificaciones.AddAsync(obj);
        }

        public async Task<Notificacion> FindById(Guid id)
        {
            Notificacion? notificacion = await Notificaciones.FindAsync(id);
            if (notificacion != null)
                return notificacion;

            return factory.CrearNotificacionVacia();
        }
    }
}
