

using Model;
using Repository.Base.GenericRepositoryImplementation;
using Repository.Connection;

namespace Repository.RepositoryImplementation
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(CreditContext dbContext) : base(dbContext)
        {
        }
    }
}
