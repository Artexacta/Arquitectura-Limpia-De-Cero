using AutoMapper;
using Domain.Models;
using Infrastructure.EF.ReadModels;

namespace Application.Profiles
{
    public class AlumnoProfile : Profile
    {
        public AlumnoProfile()
        {
            CreateMap<AlumnoReadModel, Dtos.AlumnoDto>();
            CreateMap<Alumno, Dtos.AlumnoDto>();
        }
    }
}
