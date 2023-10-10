using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.UseCases.Commands
{
    public class CreateAlumnoCommand : IRequest<AlumnoDto>
    {
        public string AlumnoACrear  { get; set; }

        public CreateAlumnoCommand(string obj)
        {
            AlumnoACrear = obj;
        }
    }
}
