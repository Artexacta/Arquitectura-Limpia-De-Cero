namespace Domain.Repositories.Shared
{
    public interface IRepository<T,Tid>
    {
        Task<T> FindByIdAsync(Tid id);
        Task CreateAsync(T o);
    }
}
