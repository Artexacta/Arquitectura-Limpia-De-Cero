using Domain.Models;
using Domain.Repositories;
using Infrastructure.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrdenDeCobroRepository : IOrdenDeCobroRepository
    {
        private DbSet<OrdenDeCobro> OrdenesDeCobro;
        public OrdenDeCobroRepository(WriteDbContext context)
        {
            OrdenesDeCobro = context.OrdenesDeCobro;
        }
        
        public async Task CreateAsync(OrdenDeCobro obj)
        {
            await OrdenesDeCobro.AddAsync(obj);
        }

        public Task<OrdenDeCobro> FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
