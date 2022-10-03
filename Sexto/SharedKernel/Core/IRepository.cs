using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedKernel.Core
{
    public interface IRepository<T,in Tid> where T : AggregateRoot<Tid>
    {
        Task<T> FindById(Tid id);
        Task CreateAsync(T obj);
    }
}
