using Application.Dtos;
using Domain.Models;
using MediatR;

namespace Application.UseCases.Commands
{
    public class CreateMateriaCommand : IRequest<MateriaDto>
    {
        public CreateMateriaCommand(string materia)
        {
            MateriaACrear = materia;
        }

        public string MateriaACrear { get; }
    }
}
