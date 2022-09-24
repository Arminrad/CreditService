using Microsoft.EntityFrameworkCore;
using Model.Entities;
using Repository.Base.GenericRepositoryImplementation;
using Repository.Connection;
using Repository.RepositoryInterface;

namespace Repository.RepositoryImplementation
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(CreditContext dbContext) : base(dbContext)
        {
        }

        public async Task<Account> GetByUserIdAsync(int userId, CancellationToken cancellationToken)
        {
            Account account = await DbContext.Accounts.SingleOrDefaultAsync(x => x.UserId == userId);
            return account;
        }
    }
}
