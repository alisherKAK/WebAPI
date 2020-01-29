namespace Domain.Infrastructure
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Save();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
