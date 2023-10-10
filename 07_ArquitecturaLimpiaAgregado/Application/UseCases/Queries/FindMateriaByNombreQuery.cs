using Application.Dtos;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindMateriaByNombreQuery : IRequest<List<MateriaDto>>
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public bool IncluirAlumnosRegistrados { get; set; }
        public FindMateriaByNombreQuery(string nombre) : this(nombre, false)
        {
        }
        public FindMateriaByNombreQuery(string nombre, bool incluirRegistrados)
        {
            Nombre = nombre;
            IncluirAlumnosRegistrados = incluirRegistrados;
            Cantidad = 1;
        }
        public FindMateriaByNombreQuery(string nombre, bool incluirRegistrados, int cantidad)
        {
            Nombre = nombre;
            IncluirAlumnosRegistrados = incluirRegistrados;
            Cantidad = cantidad;
        }
    }
}
