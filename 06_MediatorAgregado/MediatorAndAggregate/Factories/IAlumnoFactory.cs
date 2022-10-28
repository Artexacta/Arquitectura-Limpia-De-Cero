using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Factories
{
    public interface IAlumnoFactory
    {
        Alumno CrearAlumnoVacio();
        Alumno CrearNuevo(string nombre);
    }
}
