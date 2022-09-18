using CreditService.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CreditService.Repository ;

namespace CreditService.Controllers
{

   

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _accountRepository;


        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }




        [HttpPost]
        public async Task<ActionResult> CreateAccount(Account account, CancellationToken cancellationToken)
        {

            Account acc = new Account()
            {
                Balance = 0,
            };
           await  _accountRepository.AddAsync(account, cancellationToken);

           return Ok();
        }
    }
}
