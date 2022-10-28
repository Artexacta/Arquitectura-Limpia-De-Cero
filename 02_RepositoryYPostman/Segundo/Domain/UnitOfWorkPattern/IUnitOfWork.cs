namespace Segundo.Domain.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
