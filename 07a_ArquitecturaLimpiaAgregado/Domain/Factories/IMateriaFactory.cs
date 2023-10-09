using Domain.Models;

namespace Domain.Factories
{
    public interface IMateriaFactory
    {
        Materia CrearMateriaVacia();
        Materia CrearNueva(string nombre);
        Registrado CrearNuevoRegistrado(Guid alumnoId, Guid materiaId);
    }
}
