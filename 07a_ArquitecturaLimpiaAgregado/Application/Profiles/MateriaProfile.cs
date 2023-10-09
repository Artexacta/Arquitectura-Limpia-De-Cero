using AutoMapper;
using Domain.Models;
using Infrastructure.EF.ReadModels;

namespace Application.Profiles
{
    public class MateriaProfile : Profile
    {
        public MateriaProfile()
        {
            CreateMap<MateriaReadModel, ViewModels.MateriaViewModel>();
            CreateMap<Materia, ViewModels.MateriaViewModel>();
        }
    }
}
