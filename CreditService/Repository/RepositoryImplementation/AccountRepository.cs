using CreditService.Common.Connection;
using CreditService.Model;
using CreditService.Repository.Base.GenericRepositoryImplementation;

namespace CreditService.Repository.RepositoryImplementation
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
