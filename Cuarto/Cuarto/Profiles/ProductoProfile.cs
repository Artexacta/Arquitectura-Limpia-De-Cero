using AutoMapper;
using Cuarto.Models;
using Cuarto.ViewModels;

namespace Cuarto.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoViewModel>().ReverseMap();
        }
    }
}
