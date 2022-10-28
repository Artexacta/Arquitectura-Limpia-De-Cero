using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class FindRegistradosEnMateriaHandler : IRequestHandler<FindRegistradosEnMateriaQuery, List<Registrado>>
    {
        private readonly DbSet<Registrado> Registrados;
        public FindRegistradosEnMateriaHandler(WriteDbContext context)
        {
            Registrados = context.Registrados;
        }
        public async Task<List<Registrado>> Handle(FindRegistradosEnMateriaQuery request, CancellationToken cancellationToken)
        {
            return await Registrados.AsNoTracking()
                    .Where(x => x.MateriaId == request.MateriaId).ToListAsync();
        }
    }
}
