using Domain.Events;
using Domain.Exceptions;
using Domain.Factories;
using Domain.Helpers;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Consumers
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
            ConfiguracionCaso configuracionCaso = new ConfiguracionCaso();
            Alumno alumno = await _alumnoRepository.FindById(notification.AlumnoId);
            string email = alumno.Nombre + "@" + Constants.DOMINIO;
            string mensaje = Constants.MENSAJE_COBRO;
            mensaje = mensaje.Replace("{MONTO}", notification.Monto.ToString("0.00"));
            mensaje = mensaje.Replace("{NOMBRE}", alumno.Nombre);

            Notificacion notificacion =
                _notificacionFactory.CrearNueva(Guid.NewGuid(), mensaje, email);
            _logger.LogInformation("[Notificar Orden de Cobro] Notificacion creada: {0}", notificacion.Id);

            if (configuracionCaso.ErrorAlNotificarCobro)
            {
                _logger.LogInformation($"[Notificar Orden de Cobro] Error al notificar cobro a {email}");
                throw new ConfigCasoException("Error al notificar el cobro");
            }

            notificacion.ConsolidarCreada();
            _logger.LogInformation("[Notificar Orden de Cobro] Comunicar evento Notificacion Creada");

            await _notificacionRepository.CreateAsync(notificacion);
            _logger.LogInformation("[Notificar Orden de Cobro] Guardar en base de datos");

            await _unitOfWork.Commit();
            _logger.LogInformation("[Notificar Orden de Cobro] Vuelve del COMMIT");
        }
    }
}
