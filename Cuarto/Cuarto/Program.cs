using Cuarto.Domain.Persistence;
using Cuarto.Domain.UnitOfWorkPattern;
using Cuarto.Infrastructure.DbContexts;
using Cuarto.Infrastructure.Persistence;
using Cuarto.Infrastructure.UnitOfWorkPattern;
using Cuarto.ViewModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("DBConnectionString"),
                b => b.MigrationsAssembly("Cuarto")));

builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(ProductoViewModel));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
