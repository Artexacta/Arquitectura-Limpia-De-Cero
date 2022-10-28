using Tercero.Domain.UnitOfWorkPattern;
using Tercero.Infrastructure.DbContexts;

namespace Tercero.Infrastructure.UnitOfWorkPattern
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
