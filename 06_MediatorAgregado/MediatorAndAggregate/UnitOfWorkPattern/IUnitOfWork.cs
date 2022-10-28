namespace MediatorAndAggregate.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
