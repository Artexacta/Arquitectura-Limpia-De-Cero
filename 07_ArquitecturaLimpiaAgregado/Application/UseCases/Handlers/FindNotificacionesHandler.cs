using Application.UseCases.Queries;
using Application.Dtos;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindNotificacionesHandler : IRequestHandler<FindNotificacionesQuery, List<NotificacionDto>>
    {
        private readonly ReadDbContext _context;
        private readonly IMapper _mapper;

        public FindNotificacionesHandler(ReadDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<NotificacionDto>> Handle(FindNotificacionesQuery request, CancellationToken cancellationToken)
        {
            List<NotificacionReadModel> lista = await _context.Notificaciones.AsNoTracking().ToListAsync();

            List<NotificacionDto> model = new List<NotificacionDto>();
            foreach(NotificacionReadModel item in lista)
            {
                model.Add(_mapper.Map<NotificacionDto>(item));
            }

            return model;
        }
    }
}
