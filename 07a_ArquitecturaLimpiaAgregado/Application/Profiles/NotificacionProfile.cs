using AutoMapper;

namespace Application.Profiles
{
    public class NotificacionProfile : Profile
    {
        public NotificacionProfile()
        {
            CreateMap<Infrastructure.EF.ReadModels.NotificacionReadModel, ViewModels.NotificacionViewModel>();
        }
    }
}
