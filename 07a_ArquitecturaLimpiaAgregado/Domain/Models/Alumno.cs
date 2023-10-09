using Domain.Events;
using SharedKernel.Core;

namespace Domain.Models
{
    public class Alumno : AggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        public List<Materia> Registradas { get; set; }

        public Alumno(Guid id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Registradas = new List<Materia>();
        }

        public void ConsolidarCreado()
        {
            AddDomainEvent(new AlumnoCreadoEvent(Id, Nombre));
        }
    }
}
