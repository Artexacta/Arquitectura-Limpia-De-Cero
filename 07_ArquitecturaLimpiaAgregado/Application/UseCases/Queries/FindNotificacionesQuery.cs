using Application.Dtos;
using MediatR;

namespace Application.UseCases.Queries
{
    public class FindNotificacionesQuery : IRequest<List<NotificacionDto>>
    {
        public int Cantidad { get; set; }
        public FindNotificacionesQuery(int cantidad)
        {
            Cantidad = cantidad;
        }
    }
}
