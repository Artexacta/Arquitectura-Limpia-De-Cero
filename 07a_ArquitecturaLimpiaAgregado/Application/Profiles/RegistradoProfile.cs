using AutoMapper;

namespace Application.Profiles
{
    public class RegistradoProfile : Profile
    {
        public RegistradoProfile()
        {
            CreateMap<Infrastructure.EF.ReadModels.RegistradoReadModel, ViewModels.RegistradoViewModel>();
        }
    }
}
