using Application.Injections;
using Domain.Repositories.Productos;
using Domain.UnitOfWorkPattern;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Productos;
using Infrastructure.UnitOfWorkPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Infrastructure.Injections
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddApplication(configuration);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var connectionString =
                configuration.GetConnectionString("DBConnectionString");

            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IProductoRepository, ProductoRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
