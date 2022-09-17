using CreditService.Model;
using CreditService.Repository.Base.GenericRepository;

namespace CreditService.Repository
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
