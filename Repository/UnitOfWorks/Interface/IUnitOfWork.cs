using Microsoft.EntityFrameworkCore.Storage;
using Repository.RepositoryInterface;

namespace Repository.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IAccountRepository AccountRepository { get; }
        ITransactionRepository TransactionRepository { get; }

        Task<bool> SaveAsync(CancellationToken cancellationToken);
        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken);
    }
}
