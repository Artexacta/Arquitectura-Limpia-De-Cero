namespace Tercero.Domain.UnitOfWorkPattern
{
    public interface IUnitOfWork
    {
        Task Commit();
    }
}
