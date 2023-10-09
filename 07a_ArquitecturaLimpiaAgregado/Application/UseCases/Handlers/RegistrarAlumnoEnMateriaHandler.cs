using Application.UseCases.Commands;
using Domain.Exceptions;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernel.Repository;

namespace Application.UseCases.Handlers
{
    public class RegistrarAlumnoEnMateriaHandler : IRequestHandler<RegistrarAlumnoEnMateriaCommand, bool>
    {
        private readonly ILogger<RegistrarAlumnoEnMateriaHandler> _logger;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarAlumnoEnMateriaHandler(
            IUnitOfWork unitOfWork,
            ILogger<RegistrarAlumnoEnMateriaHandler> logger,
            IMateriaRepository materiaRepository,
            IAlumnoRepository alumnoRepository)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _materiaRepository = materiaRepository;
            _alumnoRepository = alumnoRepository;
        }
        public async Task<bool> Handle(RegistrarAlumnoEnMateriaCommand request, CancellationToken cancellationToken)
        {
            ConfiguracionCaso configuracionCaso = new ConfiguracionCaso();

            Alumno alumno = await _alumnoRepository.FindById(request.AlumnoId);
            Materia materia = await _materiaRepository.FindById(request.MateriaId);
            _logger.LogInformation("[REGISTRAR ALUMNO] Obtiene alumno y materia para poder trabajar estrictamente en dominio");
            
            materia.RegistrarAlumno(alumno);
            _logger.LogInformation("[REGISTRAR ALUMNO] Registra alumno en materia (en dominio solamente)");

            materia.ConsolidarRegistrado(alumno.Id, alumno.Nombre);
            _logger.LogInformation("[REGISTRAR ALUMNO] Publica el evento y lo pone en la cola");

            if (configuracionCaso.ErrorAlRegistrarAlumno)
            {
                _logger.LogInformation("[REGISTRAR ALUMNO] Error al registrar alumno");
                throw new ConfigCasoException("Error al registrar alumno");
            }
            await _materiaRepository.RegistrarAlumnoAsync(materia.Id, alumno.Id);
            _logger.LogInformation("[REGISTRAR ALUMNO] Guarda el registro del alumno en esa materia en la base de datos");
            await _unitOfWork.Commit();
            return true;
        }
    }
}
