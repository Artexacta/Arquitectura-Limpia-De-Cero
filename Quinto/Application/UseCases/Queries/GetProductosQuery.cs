using Application.Dto.Productos;
using Application.ViewModels.Productos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Queries
{
    public class GetProductosQuery : IRequest<List<ProductoDtoViewModel>>
    {
        public GetProductosQuery()
        {

        }
    }
}
