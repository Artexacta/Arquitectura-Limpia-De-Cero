using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatorAndAggregate.UseCases.Commands;
using MediatorAndAggregate.UseCases.Queries;
using MediatR;
using Microsoft.Extensions.Logging;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class RegistrarAlumnoEnMateriaHandler : IRequestHandler<RegistrarAlumnoEnMateriaCommand, bool>
    {
        private readonly ILogger<RegistrarAlumnoEnMateriaHandler> _logger;
        private readonly IMediator _mediator;
        private readonly IMateriaRepository _materiaRepository;
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RegistrarAlumnoEnMateriaHandler(
            IUnitOfWork unitOfWork,
            IMediator mediator,
            ILogger<RegistrarAlumnoEnMateriaHandler> logger,
            IMateriaRepository materiaRepository,
            IAlumnoRepository alumnoRepository)
        {
            _unitOfWork = unitOfWork;
            _mediator = mediator;
            _logger = logger;
            _materiaRepository = materiaRepository;
            _alumnoRepository = alumnoRepository;
        }
        public async Task<bool> Handle(RegistrarAlumnoEnMateriaCommand request, CancellationToken cancellationToken)
        {
            Alumno alumno = await _alumnoRepository.FindById(request.AlumnoId);
            Materia materia = await _materiaRepository.FindById(request.MateriaId);
            materia.Registrados = await _mediator.Send(new FindRegistradosEnMateriaQuery(request.MateriaId));
            _logger.LogInformation("[REGISTRAR ALUMNO] Obtiene alumno y materia para poder trabajar estrictamente en dominio");
            
            materia.RegistrarAlumno(alumno);
            _logger.LogInformation("[REGISTRAR ALUMNO] Registra alumno en materia (en dominio solamente)");

            materia.ConsolidarRegistrado(alumno.Id, alumno.Nombre);
            _logger.LogInformation("[REGISTRAR ALUMNO] Publica el evento y lo pone en la cola");

            await _materiaRepository.RegistrarAlumnoAsync(materia.Id, alumno.Id);
            _logger.LogInformation("[REGISTRAR ALUMNO] Guarda el registro del alumno en esa materia en la base de datos");
            await _unitOfWork.Commit();
            return true;
        }
    }
}
