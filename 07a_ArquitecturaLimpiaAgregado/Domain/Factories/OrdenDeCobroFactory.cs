using Domain.Models;

namespace Domain.Factories
{
    public class OrdenDeCobroFactory : IOrdenDeCobroFactory
    {
        public OrdenDeCobro CrearOrdenDeCobro(Guid id, Guid alumnoId, Guid materiaId, decimal monto)
        {
            return new OrdenDeCobro(id, alumnoId, materiaId, monto);
        }
    }
}
