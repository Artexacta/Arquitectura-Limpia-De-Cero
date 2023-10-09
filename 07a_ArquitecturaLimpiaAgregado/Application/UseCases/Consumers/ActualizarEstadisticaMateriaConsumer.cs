﻿using Domain.Events;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.EF.DbContexts;
using Infrastructure.EF.ReadModels;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SharedKernel.Repository;

namespace Application.UseCases.Consumers
{
    public class ActualizarEstadisticaMateriaConsumer : INotificationHandler<AlumnoRegistradoEvent>
    {
        private readonly ILogger<ActualizarEstadisticaMateriaConsumer> _logger;
        private DbSet<RegistradoReadModel> Registrados;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ActualizarEstadisticaMateriaConsumer(ReadDbContext context,
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
            ConfiguracionCaso configuracionCaso = new ConfiguracionCaso();
            
            int nbRegistrados = Registrados.Select(x => x.MateriaId == notification.MateriaId).Count();
            // Esto porque el alumno nuevo registrado todavia no está commiteado
            nbRegistrados++;
            Materia materia = await _materiaRepository.FindById(notification.MateriaId);

            if (configuracionCaso.ErrorAlActualizarEstadistica)
            {
                _logger.LogInformation($"[Actualizar Estadistica] Error al actualizar estadistica de {materia.Nombre}");
                throw new ConfigCasoException("Error al actualizar estadistica");
            }

            materia.ActualizarEstadistica(nbRegistrados);            
            _logger.LogInformation($"[Actualizar Estadistica] Se actualiza la estadistica de la materia {materia.Nombre} con {nbRegistrados} registrados");
            _logger.LogInformation($"[Actualizar Estadistica] Se lanza el evento de Estadistica Actualizada");
            _logger.LogInformation($"[Actualizar Estadistica] El cambio en el objeto hace el update automáticamente");

            await _unitOfWork.Commit();
            _logger.LogInformation($"[Actualizar Estadistica] Vuelve del COMMIT");
        }
    }
}
