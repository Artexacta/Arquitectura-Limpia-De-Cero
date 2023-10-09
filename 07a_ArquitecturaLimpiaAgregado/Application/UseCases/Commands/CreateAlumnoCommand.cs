using Application.ViewModels;
using Domain.Models;
using MediatR;

namespace Application.UseCases.Commands
{
    public class CreateAlumnoCommand : IRequest<AlumnoViewModel>
    {
        public string AlumnoACrear  { get; set; }

        public CreateAlumnoCommand(string obj)
        {
            AlumnoACrear = obj;
        }
    }
}
