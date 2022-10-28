using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace MediatorAndAggregate.Injections
{
    public static class Extensions
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DBConnectionString");

            services.AddDbContext<WriteDbContext>(context =>
                context.UseLoggerFactory(LoggerFactory.Create(builder =>
                    { 
                        builder.AddConsole();
                        builder.SetMinimumLevel(LogLevel.Warning);
                    }))
                .UseSqlServer(connectionString));

            services.AddSingleton<IAlumnoFactory, AlumnoFactory>();
            services.AddSingleton<IMateriaFactory, MateriaFactory>();
            services.AddSingleton<IOrdenDeCobroFactory, OrdenDeCobroFactory>();
            services.AddSingleton<INotificacionFactory, NotificacionFactory>();

            services.AddScoped<IAlumnoRepository, AlumnoRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<INotificacionRepository, NotificacionRepository>();
            services.AddScoped<IOrdenDeCobroRepository, OrdenDeCobroRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
