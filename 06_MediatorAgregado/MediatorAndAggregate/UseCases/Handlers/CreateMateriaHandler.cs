using MediatorAndAggregate.Factories;
using MediatorAndAggregate.Models;
using MediatorAndAggregate.Repositories;
using MediatorAndAggregate.UnitOfWorkPattern;
using MediatorAndAggregate.UseCases.Commands;
using MediatR;

namespace MediatorAndAggregate.UseCases.Handlers
{
    public class CreateMateriaHandler : IRequestHandler<CreateMateriaCommand, bool>
    {
        private readonly IMateriaRepository _materiaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMateriaFactory _factory;
        public CreateMateriaHandler(IMateriaRepository materiaRepository, 
            IUnitOfWork unitOfWork, 
            IMateriaFactory factory)
        {
            _materiaRepository = materiaRepository;
            _unitOfWork = unitOfWork;
            _factory = factory;
        }

        public async Task<bool> Handle(CreateMateriaCommand request, CancellationToken cancellationToken)
        {
            Materia obj = _factory.CrearNueva(request.MateriaACrear);

            obj.ConsolidarCreada();
            
            await _materiaRepository.CreateAsync(obj);
            
            await _unitOfWork.Commit();
            return true;
        }
    }
}
