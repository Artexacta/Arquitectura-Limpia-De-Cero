namespace Cuarto.Domain.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
