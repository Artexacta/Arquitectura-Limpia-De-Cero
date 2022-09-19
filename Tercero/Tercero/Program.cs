using Microsoft.EntityFrameworkCore;
using Tercero.Domain.Persistence;
using Tercero.Domain.UnitOfWorkPattern;
using Tercero.Infrastructure.DbContexts;
using Tercero.Infrastructure.Persistence;
using Tercero.Infrastructure.UnitOfWorkPattern;
using Tercero.ViewModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("DBConnectionString"),
                b => b.MigrationsAssembly("Tercero")));

builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(ProductoViewModel));

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Producto}/{action=Index}/{id?}");

app.Run();