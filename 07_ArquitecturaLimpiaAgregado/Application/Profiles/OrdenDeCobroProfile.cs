using AutoMapper;
using Infrastructure.EF.ReadModels;

namespace Application.Profiles
{
    public class OrdenDeCobroProfile : Profile
    {
        public OrdenDeCobroProfile()
        {
            CreateMap<OrdenDeCobroReadModel, Dtos.OrdenDeCobroDto>();
        }
    }
}
