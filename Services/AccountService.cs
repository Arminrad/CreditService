using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditService.Model.ApiResults;
using Model;
using Repository;

namespace Services
{
    public class AccountService: IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }



        public async Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken)
        {
            await _accountRepository.AddAsync(account, cancellationToken);
            ActionResponse actionResponse = new ActionResponse(true, ActionResultStatusCode.Created);
            return actionResponse;
        }
    }
}
