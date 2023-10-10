using Application.Dtos;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindOrdenesDeCobroQuery : IRequest<List<OrdenDeCobroDto>>
    {
        public int Cantidad { get; set; }
        public FindOrdenesDeCobroQuery(int cantidad)
        {
            Cantidad = cantidad;
        }
    }
}
