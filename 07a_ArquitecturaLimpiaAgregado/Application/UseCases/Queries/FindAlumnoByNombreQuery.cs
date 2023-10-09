using Application.ViewModels;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindAlumnoByNombreQuery : IRequest<List<AlumnoViewModel>>
    {
        public string Nombre { get; set; }
        public int Cantidad { get; set; }

        public FindAlumnoByNombreQuery(string nombre)
        {
            Nombre = nombre;
            Cantidad = 1;
        }

        public FindAlumnoByNombreQuery(string nombre, int cantidad)
        {
            Nombre = nombre;
            Cantidad = cantidad;
        }
    }
}
