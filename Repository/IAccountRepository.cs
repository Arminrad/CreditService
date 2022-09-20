using Model;
using Repository.Base.GenericRepository;

namespace Repository
{
    public interface IAccountRepository : IGenericRepository<Account>
    {

        Task<Account> GetByUserIdAsync(int userId, CancellationToken cancellationToken);
    }
}
