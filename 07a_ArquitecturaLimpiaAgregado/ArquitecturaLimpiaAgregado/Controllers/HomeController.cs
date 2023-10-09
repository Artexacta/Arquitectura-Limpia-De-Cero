using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ArquitecturaLimpiaAgregado.Models;
using Application.ViewModels;
using Application.UseCases.Handlers;
using Application.UseCases.Queries;
using MediatR;
using Infrastructure.EF.ReadModels;
using Application.UseCases.Commands;

namespace ArquitecturaLimpiaAgregado.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IMediator _mediator;

    public HomeController(ILogger<HomeController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    public async Task<IActionResult> Index()
    {
        List<AlumnoViewModel> alumnos = await _mediator.Send(new FindAlumnoByNombreQuery("", 100));
        List<MateriaViewModel> materias = await _mediator.Send(new FindMateriaByNombreQuery("", true, 100));

        HomeViewModel model = new HomeViewModel();
        model.Alumnos = alumnos;
        model.Materias = materias;
        return View(model);
    }

    public IActionResult Registro()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Registro(ConfiguracionCasoViewModel model)
    {
        // Primero buscamos el alumno y la materia
        AlumnoViewModel alumno = null;
        List<AlumnoViewModel> alumnos = 
            await _mediator.Send(new FindAlumnoByNombreQuery(model.RegistrarAlumno, 1));
        if (alumnos.Count == 0)
        {
            alumno = await _mediator.Send(new CreateAlumnoCommand(model.RegistrarAlumno));
        } else
        {
            alumno = alumnos[0];
        }

        MateriaViewModel materia = null;
        List<MateriaViewModel> materias =
            await _mediator.Send(new FindMateriaByNombreQuery(model.EnMateria, false, 1));
        if (materias.Count == 0)
        {
            materia = await _mediator.Send(new CreateMateriaCommand(model.EnMateria));
        }
        else
        {
            materia = materias[0];
        }

        bool resultado = 
            await _mediator.Send(new RegistrarAlumnoEnMateriaCommand(alumno.Id, materia.Id));

        if (resultado)
        {
            model.Mensaje = "Se registro el alumno correctamente";
        } else
        {
            model.Mensaje = "No se pudo registrar el alumno en la materia";
        }

        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
