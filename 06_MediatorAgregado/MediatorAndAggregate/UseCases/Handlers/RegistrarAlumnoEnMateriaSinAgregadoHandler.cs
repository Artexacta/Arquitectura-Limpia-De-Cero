using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Helpers;
using MediatorAndAggregate.Migrations;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatorAndAggregate.UseCases.Commands;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class RegistrarAlumnoEnMateriaSinAgregadoHandler
        : IRequestHandler<RegistrarAlumnoEnMateriaSinAgregadoCommand, bool>
    {
        private readonly ILogger<RegistrarAlumnoEnMateriaSinAgregadoHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IOrdenDeCobroFactory _ordenDeCobroFactory;
        private readonly IOrdenDeCobroRepository _ordenDeCobroRepository;
        private readonly INotificacionFactory _notificacionFactory;
        private readonly INotificacionRepository _notificacionRepository;

        public RegistrarAlumnoEnMateriaSinAgregadoHandler(ILogger<RegistrarAlumnoEnMateriaSinAgregadoHandler> logger,
            IMediator mediator,
            IMateriaRepository materiaRepository,
            IAlumnoRepository alumnoRepository,
            IUnitOfWork unitOfWork,
            IOrdenDeCobroFactory ordenDeCobroFactory,
            IOrdenDeCobroRepository ordenDeCobroRepository,
            INotificacionFactory notificacionFactory,
            INotificacionRepository notificacionRepository)
        {
            _logger = logger;
            _mediator = mediator;
            _materiaRepository = materiaRepository;
            _alumnoRepository = alumnoRepository;
            _unitOfWork = unitOfWork;
            _ordenDeCobroFactory = ordenDeCobroFactory;
            _ordenDeCobroRepository = ordenDeCobroRepository;
            _notificacionFactory = notificacionFactory;
            _notificacionRepository = notificacionRepository;
        }

        public async Task<bool> Handle(RegistrarAlumnoEnMateriaSinAgregadoCommand request, CancellationToken cancellationToken)
        {
            Alumno alumno = await _alumnoRepository.FindById(request.AlumnoId);
            Materia materia = await _materiaRepository.FindById(request.MateriaId);
            materia.Registrados = await _mediator.Send(new FindRegistradosEnMateriaQuery(request.MateriaId));
            _logger.LogInformation("[Sin Agregado] Obtiene alumno y materia para poder trabajar estrictamente en dominio");

            materia.RegistrarAlumno(alumno);
            _logger.LogInformation("[Sin Agregado] Registra alumno en materia (en dominio solamente)");
            
            await _materiaRepository.RegistrarAlumnoAsync(materia.Id, alumno.Id);
            _logger.LogInformation("[Sin Agregado] Guarda el registro del alumno en esa materia en la base de datos");

            _logger.LogInformation("[Sin Agregado] La materia actualiza nro registrados en base de datos por EF");

            // Mensaje de Bienvenida
            //-----------------------------
            string mensaje = Constants.MENSAJE_BIENVENIDA;
            mensaje = mensaje.Replace("{NOMBRE}", alumno.Nombre);
            string email = alumno.Nombre + "@" + Constants.DOMINIO;

            Notificacion notificacion =
                _notificacionFactory.CrearNueva(Guid.NewGuid(), mensaje, email);
            _logger.LogInformation("[Sin Agregado] Notificacion creada: {0}", notificacion.Id);

            await _notificacionRepository.CreateAsync(notificacion);
            _logger.LogInformation("[Sin Agregado] Grabar la notificación en la base de datos");

            // Orden de Cobro
            //--------------------------------
            OrdenDeCobro orden = _ordenDeCobroFactory.CrearOrdenDeCobro(
                    Guid.NewGuid(),
                    alumno.Id,
                    materia.Id,
                    Constants.COSTO);
            _logger.LogInformation($"[Sin Agregado] Se crea la orden de cobro a {alumno.Nombre}");
            
            await _ordenDeCobroRepository.CreateAsync(orden);
            _logger.LogInformation("[Sin Agregado] Se guarda la orden de cobro en la base de datos");
            
            mensaje = Constants.MENSAJE_COBRO;
            mensaje = mensaje.Replace("{MONTO}", orden.Monto.ToString("0.00"));
            mensaje = mensaje.Replace("{NOMBRE}", alumno.Nombre);

            notificacion =
                _notificacionFactory.CrearNueva(Guid.NewGuid(), mensaje, email);
            _logger.LogInformation("[Sin Agregado] Notificacion creada: {0}", notificacion.Id);

            await _notificacionRepository.CreateAsync(notificacion);
            _logger.LogInformation("[Sin Agregado] Guardar en base de datos");
            
            await _unitOfWork.Commit();
            return true;
        }
    }
}
