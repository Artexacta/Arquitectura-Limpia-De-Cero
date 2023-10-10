using Domain.Models;

namespace Domain.Factories
{
    public interface IOrdenDeCobroFactory
    {
        OrdenDeCobro CrearOrdenDeCobro(Guid id, Guid alumnoId, Guid materiaId, decimal monto);
    }
}
