using MediatorAndAggregate.Models;
using SharedKernel.Core;

namespace MediatorAndAggregate.Repositories
{
    public interface IMateriaRepository : IRepository<Materia,Guid>
    {
        Task RegistrarAlumnoAsync(Guid materiaId, Guid alumnoId);
    }
}
