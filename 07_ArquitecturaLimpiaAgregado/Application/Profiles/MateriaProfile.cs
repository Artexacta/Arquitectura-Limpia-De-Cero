using AutoMapper;
using Domain.Models;
using Infrastructure.EF.ReadModels;

namespace Application.Profiles
{
    public class MateriaProfile : Profile
    {
        public MateriaProfile()
        {
            CreateMap<MateriaReadModel, Dtos.MateriaDto>();
            CreateMap<Materia, Dtos.MateriaDto>();
        }
    }
}
