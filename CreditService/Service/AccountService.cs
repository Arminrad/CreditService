using CreditService.Model;
using CreditService.Repository;

namespace CreditService.Service
{
    public class AccountService : GenericService<Account, int>
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async void Delete(Account t, CancellationToken cancellationToken)
        {
            await _accountRepository.DeleteAsync(t, cancellationToken);
        }

        public  List<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public Account GetById(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Account t, CancellationToken cancellationToken)
        {
            _accountRepository.AddAsync(t, cancellationToken);
        }

        public void Update(Account t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
