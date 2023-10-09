using Application.UseCases.Queries;
using Application.ViewModels;
using AutoMapper;
using Domain.Factories;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindAlumnoByNombreHandler : 
        IRequestHandler<FindAlumnoByNombreQuery, List<AlumnoViewModel>>
    {
        private readonly DbSet<AlumnoReadModel> Alumnos;
        private readonly IMapper _mapper;
        public FindAlumnoByNombreHandler(ReadDbContext context, IMapper mapper)
        {
            Alumnos = context.Alumnos;
            _mapper = mapper;
        }
        public async Task<List<AlumnoViewModel>> Handle(
            FindAlumnoByNombreQuery request, CancellationToken cancellationToken)
        {
            List<AlumnoReadModel> alumnos =
                await Alumnos.AsNoTracking()
                    .Where(x => x.Nombre.Contains(request.Nombre))
                    .Take(request.Cantidad)
                    .ToListAsync();

            List<AlumnoViewModel> resultado = new List<AlumnoViewModel>();

            foreach(AlumnoReadModel alumno in alumnos)
            {
                resultado.Add(_mapper.Map<AlumnoViewModel>(alumno));
            }
            
            return resultado;
        }
    }
}
