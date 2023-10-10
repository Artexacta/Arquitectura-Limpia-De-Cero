using Application.UseCases.Commands;
using Application.UseCases.Queries;
using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ArquitecturaLimpiaAgregado.Controllers
{
    public class TestController : Controller
    {
        private readonly ILogger<TestController> _logger;
        private readonly IMediator _mediator;

        public TestController(ILogger<TestController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CrearMateria()
        {
            string nombre = "Programacion";
            MateriaDto materia = null;
            List<MateriaDto> materias =
                await _mediator.Send(new FindMateriaByNombreQuery(nombre, false, 1));
            if (materias.Count == 0)
            {
                materia = await _mediator.Send(new CreateMateriaCommand(nombre));
            }
            else
            {
                materia = materias[0];
            }

            return View();
        }

        public async Task<IActionResult> CrearAlumno()
        {
            string nombre = "Pedro";
            AlumnoDto alumno = null;
            List<AlumnoDto> alumnos =
                await _mediator.Send(new FindAlumnoByNombreQuery(nombre, 1));
            if (alumnos.Count == 0)
            {
                alumno = await _mediator.Send(new CreateAlumnoCommand(nombre));
            }
            else
            {
                alumno = alumnos[0];
            }

            return View(alumno);
        }
    }
}
