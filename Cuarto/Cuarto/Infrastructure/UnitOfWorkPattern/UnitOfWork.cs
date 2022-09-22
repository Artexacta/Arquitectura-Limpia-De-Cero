using Cuarto.Domain.UnitOfWorkPattern;
using Cuarto.Infrastructure.DbContexts;

namespace Cuarto.Infrastructure.UnitOfWorkPattern
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
