using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatorAndAggregate.UseCases.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class CreateAlumnoHandler : IRequestHandler<CreateAlumnoCommand, bool>
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAlumnoFactory _factory;
        public CreateAlumnoHandler(IAlumnoRepository alumnoRepository, 
            IUnitOfWork unitOfWork, 
            IAlumnoFactory factory)
        {
            _alumnoRepository = alumnoRepository;
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public async Task<bool> Handle(CreateAlumnoCommand request, CancellationToken cancellationToken)
        {
            Alumno obj = _factory.CrearNuevo(request.AlumnoACrear);

            obj.ConsolidarCreado();
            
            await _alumnoRepository.CreateAsync(obj);
            
            await _unitOfWork.Commit();
            return true;
        }
    }
}
