using Domain.UnitOfWorkPattern;
using Infrastructure.Contexts;
using MediatR;
using SharedKernel.Core;

namespace Infrastructure.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;
        private readonly IMediator _mediator;

        public UnitOfWork(WriteDbContext context, IMediator mediator)
        {
            this._context = context;
            _mediator = mediator;
        }

        public async Task Commit()
        {
            // Publicar eventos del dominio
            var domainEvents = _context.ChangeTracker.Entries<Entity<Guid>>()
                .Select(x => x.Entity.DomainEvents)
                .SelectMany(x => x)
                .ToArray();

            foreach (var domainEvent in domainEvents)
            {
                await _mediator.Publish(domainEvent);
            }
            
            await this._context.SaveChangesAsync();
        }
    }
}
