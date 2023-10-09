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
    public class CreateMateriaHandler : IRequestHandler<CreateMateriaCommand, MateriaViewModel>
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMateriaFactory _factory;
        private readonly IMapper _mapper;
        public CreateMateriaHandler(IMateriaRepository materiaRepository,
            IUnitOfWork unitOfWork,
            IMateriaFactory factory,
            IMapper mapper)
        {
            _materiaRepository = materiaRepository;
            _unitOfWork = unitOfWork;
            _factory = factory;
            _mapper = mapper;
        }

        public async Task<MateriaViewModel> Handle(CreateMateriaCommand request, CancellationToken cancellationToken)
        {
            Materia obj = _factory.CrearNueva(request.MateriaACrear);
            obj.ConsolidarCreada();            
            await _materiaRepository.CreateAsync(obj);            
            await _unitOfWork.Commit();
            
            return _mapper.Map<MateriaViewModel>(obj);
        }
    }
}
