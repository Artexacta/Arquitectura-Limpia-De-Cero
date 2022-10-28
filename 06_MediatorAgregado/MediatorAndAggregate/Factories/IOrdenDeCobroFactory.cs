using MediatorAndAggregate.Models;

namespace MediatorAndAggregate.Factories
{
    public interface IOrdenDeCobroFactory
    {
        OrdenDeCobro CrearOrdenDeCobro(Guid id, Guid alumnoId, Guid materiaId, decimal monto);
    }
}
