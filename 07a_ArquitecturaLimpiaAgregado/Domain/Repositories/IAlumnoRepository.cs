using Domain.Models;
using SharedKernel.Repository;

namespace Domain.Repositories
{
    public interface IAlumnoRepository : IRepository<Alumno, Guid>
    {
        bool RegistrarAlumno(Guid alumnoId, Guid materiaId);
    }
}
