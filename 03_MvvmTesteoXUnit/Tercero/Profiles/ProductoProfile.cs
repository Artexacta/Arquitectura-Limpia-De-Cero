using AutoMapper;
using Tercero.Models;
using Tercero.ViewModels;

namespace Tercero.Profiles
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoViewModel>();
        }
    }
}
