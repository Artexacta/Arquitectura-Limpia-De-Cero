using Application.UseCases.Commands;
using Application.ViewModels;
using AutoMapper;
using Domain.Factories;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using SharedKernel.Repository;

namespace Application.UseCases.Handlers
{
    public class CreateAlumnoHandler : IRequestHandler<CreateAlumnoCommand, AlumnoViewModel>
    {
        private readonly IAlumnoRepository _alumnoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAlumnoFactory _factory;
        private readonly IMapper _mapper;
        public CreateAlumnoHandler(IAlumnoRepository alumnoRepository,
            IUnitOfWork unitOfWork,
            IAlumnoFactory factory,
            IMapper mapper)
        {
            _alumnoRepository = alumnoRepository;
            _unitOfWork = unitOfWork;
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<AlumnoViewModel> Handle(CreateAlumnoCommand request, CancellationToken cancellationToken)
        {
            Alumno obj = _factory.CrearNuevo(request.AlumnoACrear);
            obj.ConsolidarCreado();            
            await _alumnoRepository.CreateAsync(obj);            
            await _unitOfWork.Commit();

            return _mapper.Map<AlumnoViewModel>(obj);
        }
    }
}
