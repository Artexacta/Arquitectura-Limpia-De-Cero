using MediatorAndAggregate.Events;
using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Helpers;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorAndAggregate.UseCases.Consumers
{
    public class NotificarOrdenDeCobroConsumer : INotificationHandler<OrdenDeCobroCreadaEvent>
    {
        private readonly INotificacionFactory _notificacionFactory;
        private readonly INotificacionRepository _notificacionRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotificarOrdenDeCobroConsumer> _logger;
        public NotificarOrdenDeCobroConsumer(INotificacionFactory notificacionFactory,
            INotificacionRepository notificacionRepository,
            IAlumnoRepository alumnoRepository,
            IUnitOfWork unitOfWork,
            ILogger<NotificarOrdenDeCobroConsumer> logger)
        {
            _notificacionFactory = notificacionFactory;
            _notificacionRepository = notificacionRepository;
            _alumnoRepository = alumnoRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(OrdenDeCobroCreadaEvent notification, CancellationToken cancellationToken)
        {
            Alumno alumno = await _alumnoRepository.FindById(notification.AlumnoId);
            string email = alumno.Nombre + "@" + Constants.DOMINIO;
            string mensaje = Constants.MENSAJE_COBRO;
            mensaje = mensaje.Replace("{MONTO}", notification.Monto.ToString("0.00"));
            mensaje = mensaje.Replace("{NOMBRE}", alumno.Nombre);

            Notificacion notificacion =
                _notificacionFactory.CrearNueva(Guid.NewGuid(), mensaje, email);
            _logger.LogInformation("[Notificar Orden de Cobro] Notificacion creada: {0}", notificacion.Id);

            notificacion.ConsolidarCreada();
            _logger.LogInformation("[Notificar Orden de Cobro] Comunicar evento Notificacion Creada");

            await _notificacionRepository.CreateAsync(notificacion);
            _logger.LogInformation("[Notificar Orden de Cobro] Guardar en base de datos");

            await _unitOfWork.Commit();
            _logger.LogInformation("[Notificar Orden de Cobro] COMMIT");
        }
    }
}
