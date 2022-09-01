using Segundo.Domain.UnitOfWorkPattern;
using Segundo.Infrastructure.DbContexts;

namespace Segundo.Infrastructure.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
