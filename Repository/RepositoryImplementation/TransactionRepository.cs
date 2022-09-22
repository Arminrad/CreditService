using Model.Entities;
using Repository.Base.GenericRepositoryImplementation;
using Repository.Connection;
using Repository.RepositoryInterface;

namespace CreditService.Repository.RepositoryImplementation
{
    public class TransactionRepository : GenericRepository<AccountTransaction>, ITransactionRepository
    {
        public TransactionRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
