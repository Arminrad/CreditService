using Model;
using Repository.Base.GenericRepository;

namespace Repository
{
    public interface ITransactionRepository : IGenericRepository<AccountTransaction>
    {
    }
}
