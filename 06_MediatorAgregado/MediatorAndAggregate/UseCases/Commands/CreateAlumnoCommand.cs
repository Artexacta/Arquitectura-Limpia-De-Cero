using MediatorAndAggregate.Models;
using MediatR;

namespace MediatorAndAggregate.UseCases.Commands
{
    public class CreateAlumnoCommand : IRequest<bool>
    {
        public string AlumnoACrear  { get; set; }

        public CreateAlumnoCommand(string obj)
        {
            AlumnoACrear = obj;
        }
    }
}
