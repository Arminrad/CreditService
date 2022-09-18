using Microsoft.AspNetCore.Mvc;
using Model;
using Services;

namespace CreditApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService) => _accountService = accountService;


    [HttpPost]
    public async Task<ActionResult> CreateAccount(Account account, CancellationToken cancellationToken)
    {
       return  Ok( await  _accountService.CreateAccountAsync(account, cancellationToken));
    }
}

