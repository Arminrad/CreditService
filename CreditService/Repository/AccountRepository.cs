using CreditService.Model;

namespace CreditService.Repository
{
    public class AccountRepository : GenericRepository<Account, int>
    {
        public int Delete(Account t)
        {
            throw new NotImplementedException();
            var creditContext = new CreditContext();
            var data = creditContext.Accounts.FirstOrDefault(x->x.id == t.Id);
            if(data  != null)
            {
                creditContext.Accounts.Remove(data);
                creditContext.SaveChanges();                
                return 1;
            }
            return 0;
            
        }

        public List<Account> GetAll()
        {
            throw new NotImplementedException();
            var creditContext = new CreditContext();
            if(creditContext != null)
            {
                return creditContext.Accounts.GetAll()
            }                      
        }

        public Account GetById(int id)
        {
            throw new NotImplementedException();
            var creditContext = new CreditContext();
            var data = creditContext.Accounts.GetById(id);
            if(data != null)
            {
                return data;
            }            
        }

        public int Insert(Account t)
        {
            throw new NotImplementedException();
            var creditContext = new CreditContext();
            if(creditContext.Accounts.add(t))
            {
                creditContext.SaveChanges();
                return 1;
            }                       
            return 0;            
        }

        public int Update(Account t)
        {
            throw new NotImplementedException();
            var creditContext = new CreditContext();
            var data = creditContext.Accounts.Where(x->x.id == t.Id);
            if (data != null)
            {
                data.Accounts.balance = t.balance;
                creditContext.SaveChanges();
                return 1;
            }
            return 0;
        }
    }
}
