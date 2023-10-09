using Domain.Models;
using SharedKernel.Repository;

namespace Domain.Repositories
{
    public interface IMateriaRepository : IRepository<Materia,Guid>
    {
        Task RegistrarAlumnoAsync(Guid materiaId, Guid alumnoId);
    }
}
