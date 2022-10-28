using MediatorAndAggregate.Events;
using MediatorAndAggregate.Exceptions;
using SharedKernel.Core;

namespace MediatorAndAggregate.Models
{
    public class Materia : AggregateRoot<Guid>
    {
        public string Nombre { get; private set; }
        public int Cupo { get; set; }
        public int CantidadAlumnos { get; private set; }
        public List<Registrado> Registrados { get; set; }

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
            AddDomainEvent(new MateriaCreadaEvent(this.Id, Nombre));
        }

        public void ConsolidarRegistrado(Guid alumnoId, string nombre)
        {
            string email = nombre + "@universidad.com";
            AddDomainEvent(new AlumnoRegistradoEvent(alumnoId, this.Id, nombre, email));
        }

        public void ActualizarEstadistica(int nbRegistrados)
        {
            CantidadAlumnos = nbRegistrados;
            AddDomainEvent(new EstadisticaMateriaActualizadaEvent(this.Id, CantidadAlumnos));
        }
    }
}
