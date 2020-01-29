using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IDbContextTransaction _transaction;
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
        public void CommitTransaction()
        {
            if (_transaction == null) return;
            _transaction.Commit();
        }
        public void RollbackTransaction()
        {
            if (_transaction == null) return;
            _transaction.Rollback();
        }
    }
}
