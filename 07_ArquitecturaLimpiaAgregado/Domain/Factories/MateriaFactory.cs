using Domain.Models;

namespace Domain.Factories
{
    public class MateriaFactory : IMateriaFactory
    {
        public Materia CrearMateriaVacia()
        {
            return new Materia(Guid.Empty, "", 0);
        }

        public Materia CrearNueva(string nombre)
        {
            return new Materia(Guid.NewGuid(), nombre, 5);
        }

        public Registrado CrearNuevoRegistrado(Guid alumnoId, Guid materiaId)
        {
            return new Registrado(Guid.NewGuid(), alumnoId, materiaId);            
        }
    }
}
