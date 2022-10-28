using Domain.UnitOfWorkPattern;
using Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.UnitOfWorkPattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WriteDbContext _context;

        public UnitOfWork(WriteDbContext context)
        {
            this._context = context;
        }

        public async Task Commit()
        {
            await this._context.SaveChangesAsync();
        }
    }
}
