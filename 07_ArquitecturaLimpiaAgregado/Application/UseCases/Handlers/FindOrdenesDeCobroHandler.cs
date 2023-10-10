using Application.Dtos;
using Application.UseCases.Queries;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindOrdenesDeCobroHandler : IRequestHandler<FindOrdenesDeCobroQuery, List<OrdenDeCobroDto>>
    {
        private readonly ReadDbContext _context;
        private readonly IMapper _mapper;

        public FindOrdenesDeCobroHandler(ReadDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<OrdenDeCobroDto>> Handle(FindOrdenesDeCobroQuery request, CancellationToken cancellationToken)
        {
            List<OrdenDeCobroReadModel> lista = 
                await _context.OrdenesDeCobro.AsNoTracking()
                    .Include(x => x.Alumno)
                    .Include(x => x.Materia)
            .ToListAsync();

            List<OrdenDeCobroDto> model = new List<OrdenDeCobroDto>();
            foreach (OrdenDeCobroReadModel item in lista)
            {
                model.Add(_mapper.Map<OrdenDeCobroDto>(item));
            }

            return model;
        }
    }
}
