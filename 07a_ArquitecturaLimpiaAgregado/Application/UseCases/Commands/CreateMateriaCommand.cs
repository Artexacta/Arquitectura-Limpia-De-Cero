using Application.ViewModels;
using Domain.Models;
using MediatR;

namespace Application.UseCases.Commands
{
    public class CreateMateriaCommand : IRequest<MateriaViewModel>
    {
        public CreateMateriaCommand(string materia)
        {
            MateriaACrear = materia;
        }

        public string MateriaACrear { get; }
    }
}
