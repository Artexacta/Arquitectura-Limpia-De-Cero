using Application.Dto.Productos;
using Application.ViewModels.Productos;
using AutoMapper;

namespace Infrastructure.Profiles.Productos
{
    public class ProductoDtoProfile : Profile
    {
        public ProductoDtoProfile()
        {
            CreateMap<ProductoDto, ProductoDtoViewModel>();
        }
    }
}
