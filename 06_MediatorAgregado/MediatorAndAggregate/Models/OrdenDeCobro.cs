using MediatorAndAggregate.Events;
using SharedKernel.Core;

namespace MediatorAndAggregate.Models
{
    public class OrdenDeCobro : AggregateRoot<Guid>
    {
        public Guid AlumnoId { get; private set; }
        public Guid MateriaId { get; private set; }
        public DateTime Fecha { get; private set; }
        public decimal Monto { get; private set; }
        public bool Pagado { get; private set; }

        public OrdenDeCobro(Guid id, Guid alumnoId, Guid materiaId, decimal monto)
        {
            Id = id;
            AlumnoId = alumnoId;
            MateriaId = materiaId;
            Fecha = DateTime.UtcNow;
            Monto = monto;
            Pagado = false;
        }

        public void Pagar()
        {
            Pagado = true;
        }

        public void ConsolidarCreada()
        {
            AddDomainEvent(new OrdenDeCobroCreadaEvent(MateriaId, AlumnoId, Monto));
        }
    }
}
