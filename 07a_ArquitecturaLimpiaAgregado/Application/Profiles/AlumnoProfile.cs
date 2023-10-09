using AutoMapper;
using Domain.Models;
using Infrastructure.EF.ReadModels;

namespace Application.Profiles
{
    public class AlumnoProfile : Profile
    {
        public AlumnoProfile()
        {
            CreateMap<AlumnoReadModel, ViewModels.AlumnoViewModel>();
            CreateMap<Alumno, ViewModels.AlumnoViewModel>();
        }
    }
}
