// See https://aka.ms/new-console-template for more information
using MediatorAndAggregate;
using MediatorAndAggregate.Injections;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.UseCases.Commands;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Text;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        var services = new ServiceCollection();

        // Set up configuration sources.
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(AppContext.BaseDirectory))
            .AddJsonFile("appsettings.json", optional: true);
        builder
            .AddJsonFile(
                Path.Combine(AppContext.BaseDirectory, string.Format("..{0}..{0}..{0}", Path.DirectorySeparatorChar), $"appsettings.json"),
                optional: true
            );

        var configuration = builder.Build();

        services.AddDependencies(configuration);
        services.AddMediatR(Assembly.GetExecutingAssembly());

        var provider = services.AddLogging(builder => {
            builder.ClearProviders();
            builder.AddConsole();            
        }).BuildServiceProvider();
        
        var _mediator = provider.GetRequiredService<IMediator>();
        
        ConfiguracionCaso cfg = ConfiguracionCaso.GetOrCreate();

        cfg.RegistrarAlumno = "Luis";
        cfg.EnMateria = "Algoritmos";
        cfg.SinAgregado = false;
        cfg.ErrorAlRegistrarAlumno = false;
        cfg.ErrorAlActualizarEstadistica = false;
        cfg.ErrorAlCrearCobro = false;
        cfg.ErrorAlNotificarBienvenida = false;
        cfg.ErrorAlNotificarCobro = false;

        PreparacionBaseDeDatos datos = new PreparacionBaseDeDatos(_mediator);
        await datos.PrepararAlumnos(cfg.Alumnos);
        await datos.PrepararMaterias(cfg.Materias);

        Alumno alumno = await _mediator.Send(new FindAlumnoByNombreQuery(cfg.RegistrarAlumno));
        Materia materia = await _mediator.Send(new FindMateriaByNombreQuery(cfg.EnMateria));
        
        try
        {
            if (cfg.SinAgregado)
            {
                await _mediator.Send(new RegistrarAlumnoEnMateriaSinAgregadoCommand(alumno.Id, materia.Id));
            } 
            else
            {
                await _mediator.Send(new RegistrarAlumnoEnMateriaCommand(alumno.Id, materia.Id));
            }
        } catch(Exception q)
        {
            Console.WriteLine(q.Message);
        }
    }
}