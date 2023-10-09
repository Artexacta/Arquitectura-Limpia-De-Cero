using Application.UseCases.Queries;
using Application.ViewModels;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;

using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindMateriaByNombreHandler : IRequestHandler<FindMateriaByNombreQuery, List<MateriaViewModel>>
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

        public async Task<List<MateriaViewModel>> Handle(FindMateriaByNombreQuery request, CancellationToken cancellationToken)
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
                materia.Registrados =
                    await Registrados.AsNoTracking()
                        .Where(x => x.MateriaId == materia.Id).ToListAsync();
            }

            return PatronViewModel(materias);
        }

        private List<MateriaViewModel> PatronViewModel(List<MateriaReadModel> materias)
        {
            List<MateriaViewModel> resultado = new List<MateriaViewModel>();
            foreach(MateriaReadModel materia in materias)
            {
                resultado.Add(_mapper.Map<MateriaViewModel>(materia));
            }
            return resultado;
        }
    }
}
