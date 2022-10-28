namespace Domain.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
