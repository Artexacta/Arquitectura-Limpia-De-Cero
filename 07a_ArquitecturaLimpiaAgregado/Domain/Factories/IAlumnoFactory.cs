using Domain.Models;

namespace Domain.Factories
{
    public interface IAlumnoFactory
    {
        Alumno CrearAlumnoVacio();
        Alumno CrearNuevo(string nombre);
    }
}
