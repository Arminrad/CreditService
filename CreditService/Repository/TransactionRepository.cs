using CreditService.Model;

namespace CreditService.Repository
{
    public class TransactionRepository : GenericRepository<Transaction, int>
    {
        private readonly CreditContext _creditContext;
        public AccountRepository(CreditContext creditContext)
        {
            _creditContext = creditContext;
        }

        public int Delete(Transaction t)
        {
            var data = _creditContext.Transactions.FirstOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                _creditContext.Transactions.Remove(data);
                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        public List<Transaction> GetAll()
        {
            return _creditContext.Transactions.ToList();
        }

        public Transaction GetById(int id)
        {
            return _creditContext.Transactions.SingleOrDefault(x => x.Id == id);
        }

        public async Task Insert(Transaction t)
        {
            await _creditContext.Transactions.AddAsync(t);
            _creditContext.SaveChangesAsync();
        }

        public int Update(Transaction t)
        {
            var data = _creditContext.Transactions.SingleOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                data.CustomerId = t.CustomerId;
                data.EmployerAccountId = t.EmployerAccountId;
                data.TransactionDate = t.TransactionDate;            

                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
