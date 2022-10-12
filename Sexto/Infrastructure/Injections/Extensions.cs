using Domain.Repositories.Pedidos;
using Domain.Repositories.Productos;
using Domain.UnitOfWorkPattern;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Pedidos;
using Infrastructure.Repositories.Productos;
using Infrastructure.UnitOfWorkPattern;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Injections
{
    public static class Extensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString =
                configuration.GetConnectionString("DBConnectionString");

            services.AddDbContext<WriteDbContext>(context =>
                context.UseSqlServer(connectionString));
            services.AddDbContext<ReadDbContext>(context =>
                context.UseSqlServer(connectionString));

            services.AddScoped<IProductoRepository, ProductoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
