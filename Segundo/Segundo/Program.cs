using Microsoft.EntityFrameworkCore;
using Segundo.Domain.Persistence;
using Segundo.Domain.UnitOfWorkPattern;
using Segundo.Infrastructure.DbContexts;
using Segundo.Infrastructure.Persistence;
using Segundo.Infrastructure.UnitOfWorkPattern;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                builder.Configuration.GetConnectionString("DBConnectionString"),
                b => b.MigrationsAssembly("Segundo")));

builder.Services.AddControllers();

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

app.Run();
