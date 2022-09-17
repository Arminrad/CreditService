using CreditService.Model;

namespace CreditService.Repository
{
    public class AccountRepository : GenericRepository<Account, int>
    {

        private readonly CreditContext _creditContext;

        public AccountRepository(CreditContext creditContext)
        {
            _creditContext = creditContext;
        }


        public int Delete(Account t)
        {
            var data = _creditContext.Accounts.FirstOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                _creditContext.Accounts.Remove(data);
                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;

        }

        public List<Account> GetAll()
        {
            return _creditContext.Accounts.ToList();
        }

        public Account GetById(int id)
        {
            return _creditContext.Accounts.SingleOrDefault(x => x.Id == id);
        }

        public async Task Insert(Account t)
        {
            await _creditContext.Accounts.AddAsync(t);
            _creditContext.SaveChangesAsync();
        }

        public int Update(Account t)
        {
            var data = _creditContext.Accounts.SingleOrDefault(x => x.Id == t.Id);
            if (data != null)
            {
                data.Balance = t.Balance;
                _creditContext.SaveChangesAsync();
                return 1;
            }
            return 0;
        }

        int GenericRepository<Account, int>.Insert(Account t)
        {
            throw new NotImplementedException();
        }
    }
}
