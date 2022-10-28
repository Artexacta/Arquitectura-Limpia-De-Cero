using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class FindAlumnoByNombreHandler : IRequestHandler<FindAlumnoByNombreQuery, Alumno>
    {
        private readonly DbSet<Alumno> Alumnos;
        private readonly IAlumnoFactory AlumnoFactory;
        public FindAlumnoByNombreHandler(WriteDbContext context, IAlumnoFactory alumnoFactory)
        {
            Alumnos = context.Alumnos;
            this.AlumnoFactory = alumnoFactory;
        }
        public async Task<Alumno> Handle(FindAlumnoByNombreQuery request, CancellationToken cancellationToken)
        {
            Alumno? alumno = 
                await Alumnos.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Nombre.Contains(request.Nombre));
            if (alumno == null)
            {
                alumno = AlumnoFactory.CrearAlumnoVacio();
            }
            return alumno;
        }
    }
}
