using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Ilovecode.EFCore.RepositoryBase.Transactions
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        void CommitTransaction();
        Task CommitTransactionAsync(CancellationToken cancellationToken=default);
        void RollbackTransaction();
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Salva alterações
        /// </summary>
        void SaveChanges();

        void Dispose();

        Task DisposeAsync();
    }

    
}
