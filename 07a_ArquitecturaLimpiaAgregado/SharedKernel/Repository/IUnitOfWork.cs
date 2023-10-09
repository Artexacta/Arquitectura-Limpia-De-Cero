namespace SharedKernel.Repository
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
