using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Events;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MediatorAndAggregate.UseCases.Consumers
{
    public class ActualizarEstadisticaMateriaConsumer : INotificationHandler<AlumnoRegistradoEvent>
    {
        private readonly ILogger<ActualizarEstadisticaMateriaConsumer> _logger;
        private DbSet<Registrado> Registrados;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarEstadisticaMateriaConsumer(WriteDbContext context,
            ILogger<ActualizarEstadisticaMateriaConsumer> logger,
            IMateriaRepository materiaRepository,
            IUnitOfWork unitOfWork)
        {
            Registrados = context.Registrados;
            _logger = logger;
            _materiaRepository = materiaRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(AlumnoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            int nbRegistrados = Registrados.Select(x => x.MateriaId == notification.MateriaId).Count();
            // Esto porque el alumno nuevo registrado todavia no está commiteado
            nbRegistrados++;
            Materia materia = await _materiaRepository.FindById(notification.MateriaId);

            materia.ActualizarEstadistica(nbRegistrados);            
            _logger.LogInformation($"[CONSUMER: ACTUALIZAR ESTADISTICA] Se actualiza la estadistica de la materia {notification.MateriaId} con {nbRegistrados} registrados");
            _logger.LogInformation($"[CONSUMER: ACTUALIZAR ESTADISTICA] Se lanza el evento de Estadistica Actualizada");
            _logger.LogInformation($"[CONSUMER: ACTUALIZAR ESTADISTICA] El cambio en el objeto hace el update automáticamente");

            await _unitOfWork.Commit();
            _logger.LogInformation($"[CONSUMER: ACTUALIZAR ESTADISTICA] COMMIT");
        }
    }
}
