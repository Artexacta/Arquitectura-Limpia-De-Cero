using MediatR;

namespace MediatorAndAggregate.UseCases.Commands
{
    public class CreateOrdenDeCobroCommand : IRequest<Guid>
    {
        public CreateOrdenDeCobroCommand(Guid materiaId, Guid alumnoId, decimal monto)
        {
            MateriaId = materiaId;
            AlumnoId = alumnoId;
            Monto = monto;
        }
        public Guid MateriaId { get; set; }
        public Guid AlumnoId { get; }
        public decimal Monto { get; }
    }
}
