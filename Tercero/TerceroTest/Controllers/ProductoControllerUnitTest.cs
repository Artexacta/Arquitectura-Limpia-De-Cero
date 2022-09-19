using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Tercero.Controllers;
using Tercero.Models;
using Tercero.Profiles;
using Tercero.ViewModels;
using TerceroTest.Mocks;
using Xunit;

namespace TerceroTest.Controllers
{
    public class ProductoControllerUnitTest
    {
        public IMapper GetMapper()
        {
            var mappingProfile = new ProductoProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(mappingProfile));
            return new Mapper(configuration);
        }

        [Fact]
        public void LlamadaIndexNormal()
        {
            // Arrange
            var repositoryMock = MockProductoRepository.GetMock();
            var mapper = GetMapper();

            var productoController = new ProductoController(repositoryMock.Object, mapper);

            // Act
            var result = productoController.Index();

            // Assert  
            var viewResult = Assert.IsType<ViewResult>(result);
            var viewModel = Assert.IsType<List<ProductoViewModel>>(viewResult.Model);
            Assert.Single(viewModel);
        }
    }
}
