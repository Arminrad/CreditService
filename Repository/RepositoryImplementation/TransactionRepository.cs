
using Model;
using Repository;
using Repository.Base.GenericRepositoryImplementation;
using Repository.Connection;

namespace CreditService.Repository.RepositoryImplementation
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
