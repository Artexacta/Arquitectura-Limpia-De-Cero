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

        Console.WriteLine("Hello, World!");

        ConfiguracionCaso cfg = ConfiguracionCaso.GetOrCreate();

        cfg.ErrorEnLevel0 = false;
        cfg.ErrorEnLevel1 = false;
        cfg.ExecuteLevel2 = true;
        cfg.ErrorEnLevel2 = false;

        PreparacionBaseDeDatos datos = new PreparacionBaseDeDatos(_mediator);
        await datos.PrepararAlumnos();
        await datos.PrepararMaterias();

        Alumno alumno = await _mediator.Send(new FindAlumnoByNombreQuery("Hugo"));
        Materia materia = await _mediator.Send(new FindMateriaByNombreQuery("Algoritmos"));
        
        try
        {
            await _mediator.Send(new RegistrarAlumnoEnMateriaSinAgregadoCommand(alumno.Id, materia.Id));
        } catch(Exception q)
        {
            Console.WriteLine(q.Message);
        }
    }
}