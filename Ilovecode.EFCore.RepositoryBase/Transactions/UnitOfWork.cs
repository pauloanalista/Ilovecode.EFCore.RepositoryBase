using Ilovecode.EFCore.RepositoryBase.Transactions;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace Ilovecode.EF.Repository.Transactions
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _dbContext;
        private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction _dbContextTransaction;
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual void BeginTransaction()
        {
            _dbContextTransaction = _dbContext.Database.BeginTransaction();
        }

        public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            _dbContextTransaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);
        }

        public virtual void CommitTransaction()
        {
            _dbContextTransaction.Commit();
        }

        public virtual async Task CommitTransactionAsync(CancellationToken cancellationToken)
        {
            await _dbContextTransaction.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContextTransaction.Dispose();
        }


        public virtual async Task DisposeAsync()
        {
            await _dbContextTransaction.DisposeAsync();
        }

        public virtual void RollbackTransaction()
        {
            _dbContextTransaction.Rollback();
        }

        public virtual async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            await _dbContextTransaction.RollbackAsync(cancellationToken);

        }

        public virtual void SaveChanges()
        {
            _dbContext.SaveChanges();

        }
    }
}
