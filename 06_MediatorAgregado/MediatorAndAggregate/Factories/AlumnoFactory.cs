using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Factories
{
    public class AlumnoFactory : IAlumnoFactory
    {
        public Alumno CrearAlumnoVacio()
        {
            return new Alumno(Guid.Empty, "");
        }

        public Alumno CrearNuevo(string nombre)
        {
            return new Alumno(Guid.NewGuid(), nombre);
        }
    }
}
