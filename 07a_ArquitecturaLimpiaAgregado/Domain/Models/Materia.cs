using Domain.Events;
using Domain.Exceptions;
using SharedKernel.Core;

namespace Domain.Models
{
    public class Materia : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }
        public int Cupo { get; set; }
        public int CantidadAlumnos { get; private set; }
        private readonly List<Registrado> Registrados;

        public Materia(Guid id, string nombre, int cupo)
        {
            Id = id;
            Nombre = nombre;
            CantidadAlumnos = 0;
            Cupo = cupo;
            Registrados = new List<Registrado>();
        }

        public void RegistrarAlumno(Alumno alumno)
        {
            if (CantidadAlumnos >= Cupo)
            {
                throw new NoHayCupoException($"No hay cupo disponible para la materia {Nombre}");
            }

            if (Registrados.Any(x => x.AlumnoId == alumno.Id))
            {
                throw new AlumnoYaRegistradoException($"El alumno {alumno.Nombre} ya está registrado en la materia {Nombre}");
            }

            Registrados.Add(new Registrado(Guid.NewGuid(), alumno.Id, Id));
            CantidadAlumnos++;
        }

        public void ConsolidarCreada()
        {
            AddDomainEvent(new MateriaCreadaEvent(Id, Nombre));
        }

        public void ConsolidarRegistrado(Guid alumnoId, string nombre)
        {
            string email = nombre + "@universidad.com";
            AddDomainEvent(new AlumnoRegistradoEvent(alumnoId, Id, nombre, email));
        }

        public void ActualizarEstadistica(int nbRegistrados)
        {
            CantidadAlumnos = nbRegistrados;
            AddDomainEvent(new EstadisticaMateriaActualizadaEvent(Id, CantidadAlumnos));
        }
    }
}
