using MediatorAndAggregate.Models;
using MediatR;

namespace MediatorAndAggregate.UseCases.Queries
{
    public class FindMateriaByNombreQuery : IRequest<Materia>
    {
        public string Nombre { get; set; }
        public bool IncluirAlumnosRegistrados { get; set; }
        public FindMateriaByNombreQuery(string nombre) : this(nombre, false)
        {
        }
        public FindMateriaByNombreQuery(string nombre, bool incluirRegistrados)
        {
            Nombre = nombre;
            IncluirAlumnosRegistrados = incluirRegistrados;
        }
    }
}
