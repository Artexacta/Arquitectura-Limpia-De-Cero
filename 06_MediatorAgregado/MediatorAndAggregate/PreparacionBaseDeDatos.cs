using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.UseCases.Commands;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;

namespace MediatorAndAggregate
{
    public class PreparacionBaseDeDatos
    {
        private readonly IMediator _mediator;

        public PreparacionBaseDeDatos(IMediator mediator)
        {
            _mediator = mediator;
        }

        public PreparacionBaseDeDatos()
        {
        }

        public async Task PrepararAlumnos(string[] alumnos)
        {
            IAlumnoFactory factory = new AlumnoFactory();           

            foreach (var alumno in alumnos)
            {
                Alumno obj = await _mediator.Send(new FindAlumnoByNombreQuery(alumno));
                if (obj.Id == Guid.Empty)
                {
                    await _mediator.Send(new CreateAlumnoCommand(alumno));
                    Console.WriteLine($"Creado alumno con nombre {alumno}");
                }
                else
                {
                    Console.WriteLine($"El alumno {alumno} ya existe");
                }
            }
        }

        public async Task PrepararMaterias(string[] materias)
        {
            IMateriaFactory factory = new MateriaFactory();

            foreach (var materia in materias)
            {
                Materia obj = await _mediator.Send(new FindMateriaByNombreQuery(materia));
                if (obj.Id == Guid.Empty)
                {
                    await _mediator.Send(new CreateMateriaCommand(materia));
                    Console.WriteLine($"Creada materia con nombre {materia}");
                }
                else
                {
                    Console.WriteLine($"La materia {materia} ya existe");
                }
            }
        }
    }
}
