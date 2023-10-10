using Application.UseCases.Queries;
using Application.Dtos;
using AutoMapper;
using Domain.Factories;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindAlumnoByNombreHandler : 
        IRequestHandler<FindAlumnoByNombreQuery, List<AlumnoDto>>
    {
        private readonly DbSet<AlumnoReadModel> Alumnos;
        private readonly IMapper _mapper;
        public FindAlumnoByNombreHandler(ReadDbContext context, IMapper mapper)
        {
            Alumnos = context.Alumnos;
            _mapper = mapper;
        }
        public async Task<List<AlumnoDto>> Handle(
            FindAlumnoByNombreQuery request, CancellationToken cancellationToken)
        {
            List<AlumnoReadModel> alumnos =
                await Alumnos.AsNoTracking()
                    .Where(x => x.Nombre.Contains(request.Nombre))
                    .Take(request.Cantidad)
                    .ToListAsync();

            List<AlumnoDto> resultado = new List<AlumnoDto>();

            foreach(AlumnoReadModel alumno in alumnos)
            {
                resultado.Add(_mapper.Map<AlumnoDto>(alumno));
            }
            
            return resultado;
        }
    }
}
