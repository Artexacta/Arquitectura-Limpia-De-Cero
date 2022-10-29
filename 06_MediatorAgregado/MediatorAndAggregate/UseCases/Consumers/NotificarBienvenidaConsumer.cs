using MediatorAndAggregate.Events;
using MediatorAndAggregate.Exceptions;
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
    public class NotificarBienvenidaConsumer : INotificationHandler<AlumnoRegistradoEvent>
    {
        private readonly INotificacionRepository _notificacionRepository;
        private readonly INotificacionFactory _notificacionFactory;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NotificarBienvenidaConsumer> _logger;
        public NotificarBienvenidaConsumer(INotificacionFactory notificacionFactory,
            INotificacionRepository notificacionRepository,
            IUnitOfWork unitOfWork,
            ILogger<NotificarBienvenidaConsumer> logger)
        {
            _notificacionFactory = notificacionFactory;
            _notificacionRepository = notificacionRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(AlumnoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            ConfiguracionCaso configuracionCaso = ConfiguracionCaso.GetOrCreate();
            string mensaje = Constants.MENSAJE_BIENVENIDA;
            mensaje = mensaje.Replace("{NOMBRE}", notification.NombreAlumno);

            Notificacion notificacion = 
                _notificacionFactory.CrearNueva(Guid.NewGuid(), mensaje, notification.Email);
            _logger.LogInformation("[Notificar Bienvenida] Notificacion creada: {0}", notificacion.Id);

            if (configuracionCaso.ErrorAlNotificarBienvenida)
            {
                _logger.LogInformation($"[Notificar Bienvenida] Error al notificar bienvenida a {notification.NombreAlumno}");
                throw new ConfigCasoException("Error al notificar la bienvenida");
            }

            notificacion.ConsolidarCreada();
            _logger.LogInformation("[Notificar Bienvenida] Comunicar evento Notificacion Creada");

            await _notificacionRepository.CreateAsync(notificacion);
            _logger.LogInformation("[Notificar Bienvenida] Grabar la notificación en la base de datos");

            await _unitOfWork.Commit();
            _logger.LogInformation("[Notificar Bienvenida] Vuelve del COMMIT");
        }
    }
}
