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

        public async Task PrepararAlumnos()
        {
            IAlumnoFactory factory = new AlumnoFactory();
            string[] alumnos = { "Hugo", "Paco", "Luis", "Maria" };

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

        public async Task PrepararMaterias()
        {
            IMateriaFactory factory = new MateriaFactory();
            string[] materias = { "Programación II","Investigación Operativa","Cálculo II", "Algoritmos" };

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
