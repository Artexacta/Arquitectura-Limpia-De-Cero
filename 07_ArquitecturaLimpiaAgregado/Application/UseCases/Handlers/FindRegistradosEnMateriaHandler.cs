using Application.UseCases.Queries;
using Application.Dtos;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindRegistradosEnMateriaHandler : 
        IRequestHandler<FindRegistradosEnMateriaQuery, List<RegistradoDto>>
    {
        private readonly DbSet<RegistradoReadModel> Registrados;
        private readonly IMapper _mapper;
        public FindRegistradosEnMateriaHandler(ReadDbContext context, IMapper mapper)
        {
            Registrados = context.Registrados;
            _mapper = mapper;
        }
        public async Task<List<RegistradoDto>> Handle(
            FindRegistradosEnMateriaQuery request, CancellationToken cancellationToken)
        {
            List<RegistradoReadModel> registrados = await Registrados.AsNoTracking()
                    .Where(x => x.MateriaId == request.MateriaId).ToListAsync();

            List<RegistradoDto> model = new List<RegistradoDto>();
            foreach(RegistradoReadModel obj in registrados)
            {
                model.Add(_mapper.Map<RegistradoDto>(obj));
            }

            return model;
        }
    }
}
