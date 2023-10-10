using SharedKernel.Core;

namespace SharedKernel.Repository
{
    public interface IRepository<T, in Tid> where T : AggregateRoot<Tid>
    {
        Task<T> FindById(Tid id);
        Task CreateAsync(T obj);
    }
}
