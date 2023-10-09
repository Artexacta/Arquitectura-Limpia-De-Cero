using Domain.Factories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Injections
{
    public static class Extensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddSingleton<IAlumnoFactory, AlumnoFactory>();
            services.AddSingleton<IMateriaFactory, MateriaFactory>();
            services.AddSingleton<IOrdenDeCobroFactory, OrdenDeCobroFactory>();
            services.AddSingleton<INotificacionFactory, NotificacionFactory>();

            return services;
        }
    }
}
