using MediatorAndAggregate.DbContexts;
using MediatorAndAggregate.Models;
using Microsoft.EntityFrameworkCore;

namespace MediatorAndAggregate.Repositories
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
