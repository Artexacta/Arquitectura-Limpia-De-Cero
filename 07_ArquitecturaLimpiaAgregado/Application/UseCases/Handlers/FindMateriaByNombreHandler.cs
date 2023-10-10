using Application.Dtos;
using Application.UseCases.Queries;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindMateriaByNombreHandler : IRequestHandler<FindMateriaByNombreQuery, List<MateriaDto>>
    {
        private DbSet<MateriaReadModel> Materias;
        private DbSet<RegistradoReadModel> Registrados;
        private IMapper _mapper;

        public FindMateriaByNombreHandler(ReadDbContext context, IMapper mapper)
        {
            Materias = context.Materias;
            Registrados = context.Registrados;
            _mapper = mapper;
        }

        public async Task<List<MateriaDto>> Handle(FindMateriaByNombreQuery request, CancellationToken cancellationToken)
        {
            List<MateriaReadModel> materias =
                await Materias.AsNoTracking()
                    .Where(x => x.Nombre.Contains(request.Nombre))
                    .Take(request.Cantidad)
                    .ToListAsync();
            
            if (!request.IncluirAlumnosRegistrados)
            {
                return PatronViewModel(materias);
            }

            foreach (MateriaReadModel materia in materias)
            {
                materia.ColocarEnRegistrados(
                    await Registrados.AsNoTracking()
                        .Include(x => x.Alumno)
                        .Where(x => x.MateriaId == materia.Id).ToListAsync());
            }

            return PatronViewModel(materias);
        }

        private List<MateriaDto> PatronViewModel(List<MateriaReadModel> materias)
        {
            List<MateriaDto> resultado = new List<MateriaDto>();
            foreach(MateriaReadModel materia in materias)
            {
                MateriaDto mvm = _mapper.Map<MateriaDto>(materia);
                foreach (RegistradoReadModel registrado in materia.Registrados)
                {
                    mvm.AlumnosRegistrados.Add(_mapper.Map<AlumnoDto>(registrado.Alumno));
                }
                resultado.Add(mvm);
            }
            return resultado;
        }
    }
}
