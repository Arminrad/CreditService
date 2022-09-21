using Common.ActionResult;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model;
using Repository;
using Common.ActionResult;
using Common.Utilities;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ILogger<AccountService> _logger;



        public AccountService(IAccountRepository accountRepository, ILogger<AccountService> logger)
        {
            _accountRepository = accountRepository;
            _logger = logger;
        }



        public async Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken = default)
        {
            if (!await _accountRepository.TableNoTracking.AnyAsync(x => x.UserId == account.UserId))
            {
                await _accountRepository.AddAsync(account, cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Created);
            }

            return new ActionResponse(false, ActionResultStatusCode.Exist);
        }

        public async Task<ActionResponse> IncreaseBalanceAsync(int userId,decimal amount,CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId, cancellationToken);
           Assert.NotNull(account, nameof(Account));
           account.Balance += amount;
           return new ActionResponse(true, ActionResultStatusCode.Success);
        }

        public async Task<ActionResponse> DecreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _accountRepository.GetByUserIdAsync(userId, cancellationToken);
            Assert.NotNull(account, nameof(Account));
            if (account.Balance < amount)
            {
                return new ActionResponse(false, ActionResultStatusCode.Insufficient);
            }
            account.Balance -= amount;
            return new ActionResponse(true, ActionResultStatusCode.Success);
        }

    }
}
