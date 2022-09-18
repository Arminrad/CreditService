using CreditService.Common.Connection;
using CreditService.Model;
using CreditService.Repository.Base.GenericRepositoryImplementation;

namespace CreditService.Repository.RepositoryImplementation
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
