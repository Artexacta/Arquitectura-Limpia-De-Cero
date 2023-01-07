using Microsoft.AspNetCore.Mvc;
using Primero.Models;
using Primero.Services;
using System.Diagnostics;

namespace Primero.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReversaString _reversaString;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger,
            IReversaString reversaString,
            IConfiguration configuration)
        {
            _logger = logger;
            _reversaString = reversaString;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            string nombreAplicacion = "Primero";
            if (!string.IsNullOrWhiteSpace(_configuration.GetValue<string>("NombreAplicacion")))
            {
                nombreAplicacion = _configuration.GetValue<string>("NombreAplicacion");
            }

            PersonaViewModel persona = new PersonaViewModel();
            persona.Nombre = "Juan PErez";
            persona.Edad = 45;
            persona.NombreInverso = _reversaString.Reversa(persona.Nombre);
            persona.NombreAplicacion = nombreAplicacion;
            return View(persona);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}