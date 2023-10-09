using Domain.Factories;
using Domain.Repositories;
using Infrastructure.EF.DbContexts;
using Infrastructure.Repositories;
using Infrastructure.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Injections
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString =
            configuration.GetConnectionString("DBConnectionString");

            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));
            
            services.AddDbContext<ReadDbContext>(options =>
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly("Infrastructure")));
            
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IAlumnoRepository, AlumnoRepository>();
            services.AddScoped<IMateriaRepository, MateriaRepository>();
            services.AddScoped<INotificacionRepository, NotificacionRepository>();
            services.AddScoped<IOrdenDeCobroRepository, OrdenDeCobroRepository>();

            return services;
        }
    }
}
