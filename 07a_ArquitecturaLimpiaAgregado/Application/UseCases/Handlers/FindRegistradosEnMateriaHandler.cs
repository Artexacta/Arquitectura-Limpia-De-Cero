using Application.UseCases.Queries;
using Application.ViewModels;
using AutoMapper;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.UseCases.Handlers
{
    public class FindRegistradosEnMateriaHandler : 
        IRequestHandler<FindRegistradosEnMateriaQuery, List<RegistradoViewModel>>
    {
        private readonly DbSet<RegistradoReadModel> Registrados;
        private readonly IMapper _mapper;
        public FindRegistradosEnMateriaHandler(ReadDbContext context, IMapper mapper)
        {
            Registrados = context.Registrados;
            _mapper = mapper;
        }
        public async Task<List<RegistradoViewModel>> Handle(
            FindRegistradosEnMateriaQuery request, CancellationToken cancellationToken)
        {
            List<RegistradoReadModel> registrados = await Registrados.AsNoTracking()
                    .Where(x => x.MateriaId == request.MateriaId).ToListAsync();

            List<RegistradoViewModel> model = new List<RegistradoViewModel>();
            foreach(RegistradoReadModel obj in registrados)
            {
                model.Add(_mapper.Map<RegistradoViewModel>(obj));
            }

            return model;
        }
    }
}
