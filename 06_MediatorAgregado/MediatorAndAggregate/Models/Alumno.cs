using MediatorAndAggregate.Events;
using SharedKernel.Core;

namespace MediatorAndAggregate.Models
{
    public class Alumno : AggregateRoot<Guid>
    {        
        public string Nombre { get; set; }

        public Alumno(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public void ConsolidarCreado()
        {
            AddDomainEvent(new AlumnoCreadoEvent(Id, Nombre));
        }
    }
}
