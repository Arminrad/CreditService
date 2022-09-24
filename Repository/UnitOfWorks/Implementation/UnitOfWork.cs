using Microsoft.EntityFrameworkCore.Storage;
using Repository.Connection;
using Repository.RepositoryImplementation;
using Repository.RepositoryInterface;

namespace Repository.UnitOfWorks
{
    public partial class UnitOfWork : IUnitOfWork
    {
        private readonly CreditContext _creditContext;
        public UnitOfWork(CreditContext creditContext)
        {
            _creditContext = creditContext;
        }

        public IAccountRepository AccountRepository => new AccountRepository(_creditContext);
        public ITransactionRepository TransactionRepository => new TransactionRepository(_creditContext);

        public async Task<bool> SaveAsync(CancellationToken cancellationToken)
        {
            return await _creditContext.SaveChangesAsync() > 0;
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
        {
            return await _creditContext.Database.BeginTransactionAsync(cancellationToken);
        }
    }
}
