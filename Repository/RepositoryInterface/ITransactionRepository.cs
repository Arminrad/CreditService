using Model.Entities;
using Repository.Base.GenericRepositoryInterface;

namespace Repository.RepositoryInterface
{
    public interface ITransactionRepository : IGenericRepository<AccountTransaction>
    {
    }
}
