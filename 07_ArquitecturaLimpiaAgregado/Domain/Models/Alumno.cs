using Domain.Events;
using SharedKernel.Core;

namespace Domain.Models
{
    public class Alumno : AggregateRoot<Guid>
    {
        public string Nombre { get; set; }
        private readonly List<Materia> Registradas;

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
