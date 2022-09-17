using CreditService.Model;

namespace CreditService.Repository
{
    public class TransactionRecordsRepository : GenericRepository<TransactionRecords, int>
    { 
        private readonly CreditContext _creditContext;
        public AccountRepository(CreditContext creditContext)
        {
            _creditContext = creditContext;       

        }
        public int Delete(TransactionRecords t)
        {
        
        var data = _creditContext.TransactionRecords.FirstOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                _creditContext.Accounts.Remove(data);
                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
        public List<TransactionRecords> GetAll()
        {
            return _creditContext.TransactionRecords.ToList();
        }

        public TransactionRecords GetById(int id)
        {
            return _creditContext.TransactionRecords.SingleOrDefault(x => x.Id == id);
        }

        public async Task Insert(TransactionRecords t)
        {
            await _creditContext.TransactionRecords.AddAsync(t);
            _creditContext.SaveChangesAsync();
        }

        public int Update(TransactionRecords t)
        {
            var data = _creditContext.TransactionRecords.SingleOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                data.UserId = t.UserId;
                data.Amount = t.Amount;
                data.IsDeposit = t.IsDeposit;
                data.TransactionTime = t.TransactionTime;

                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }
    }
}
