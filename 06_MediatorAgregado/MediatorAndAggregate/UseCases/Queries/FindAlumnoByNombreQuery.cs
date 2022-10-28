using MediatorAndAggregate.Models;
using MediatR;

namespace MediatorAndAggregate.UseCases.Queries
{
    public class FindAlumnoByNombreQuery : IRequest<Alumno>
    {
        public string Nombre { get; set; }

        public FindAlumnoByNombreQuery(string nombre)
        {
            Nombre = nombre;
        }
    }
}
