using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class FindMateriaByNombreHandler : IRequestHandler<FindMateriaByNombreQuery, Materia>
    {
        private DbSet<Materia> Materias;
        private DbSet<Registrado> Registrados;
        private IMateriaFactory materiaFactory;

        public FindMateriaByNombreHandler(WriteDbContext context,
            IMateriaFactory materiaFactory)
        {
            Materias = context.Materias;
            Registrados = context.Registrados;
            this.materiaFactory = materiaFactory;
        }

        public async Task<Materia> Handle(FindMateriaByNombreQuery request, CancellationToken cancellationToken)
        {
            Materia? materia = 
                await Materias.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Nombre.Contains(request.Nombre));
            
            if (materia == null)
            {
                materia = materiaFactory.CrearMateriaVacia();
                return materia;
            }
            if (!request.IncluirAlumnosRegistrados)
            {
                return materia;
            }

            materia.Registrados = 
                await Registrados.AsNoTracking()
                    .Where(x => x.MateriaId == materia.Id).ToListAsync();
            return materia;
        }
    }
}
