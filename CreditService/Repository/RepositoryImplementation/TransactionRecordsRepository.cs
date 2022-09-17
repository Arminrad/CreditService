using CreditService.Common.Connection;
using CreditService.Model;
using CreditService.Repository.Base.GenericRepositoryImplementation;

namespace CreditService.Repository.RepositoryImplementation
{
    public class TransactionRecordsRepository : GenericRepository<TransactionRecords>, ITransactionRecordsRepository
    {
        public TransactionRecordsRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
