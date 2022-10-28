using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Repositories
{
    public interface IAlumnoRepository : SharedKernel.Core.IRepository<Alumno, Guid>
    {
        bool RegistrarAlumno(Guid alumnoId, Guid materiaId);
    }
}
