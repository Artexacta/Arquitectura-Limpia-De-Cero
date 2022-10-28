using MediatorAndAggregate.Events;
using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Helpers;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorAndAggregate.UseCases.Consumers
{
    public class CrearOrdenDeCobroConsumer : INotificationHandler<AlumnoRegistradoEvent>
    {
        private readonly IOrdenDeCobroFactory _ordenDeCobroFactory;
        private readonly IOrdenDeCobroRepository _ordenDeCobroRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<CrearOrdenDeCobroConsumer> _logger;
        public CrearOrdenDeCobroConsumer(IOrdenDeCobroFactory ordenDeCobroFactory,
            IOrdenDeCobroRepository ordenDeCobroRepository,
            IUnitOfWork unitOfWork,
            ILogger<CrearOrdenDeCobroConsumer> logger)
        {
            _ordenDeCobroFactory = ordenDeCobroFactory;
            _ordenDeCobroRepository = ordenDeCobroRepository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task Handle(AlumnoRegistradoEvent notification, CancellationToken cancellationToken)
        {
            OrdenDeCobro orden = _ordenDeCobroFactory.CrearOrdenDeCobro(
                    Guid.NewGuid(), 
                    notification.AlumnoId, 
                    notification.MateriaId, 
                    Constants.COSTO);
            _logger.LogInformation($"[Crear Orden de Cobro] Se crea la orden de cobro a {notification.NombreAlumno}");

            orden.ConsolidarCreada();
            _logger.LogInformation("[Crear Orden de Cobro] Se lanza el evento Orden de Cobro Creada");

            await _ordenDeCobroRepository.CreateAsync(orden);
            _logger.LogInformation("[Crear Orden de Cobro] Se guarda la orden de cobro en la base de datos");

            await _unitOfWork.Commit();
            _logger.LogInformation("[Crear Orden de Cobro] COMMIT");
        }
    }
}
