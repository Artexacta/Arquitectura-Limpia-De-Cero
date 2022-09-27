using Application.UseCases.Commands.Productos;
using Application.ViewModels.Productos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Profiles.Productos
{
    public class ProductoDtoViewModelCreateProductoProfile : Profile
    {
        public ProductoDtoViewModelCreateProductoProfile()
        {
            CreateMap<ProductoDtoViewModel, CreateProductoCommand>();
        }
    }
}
