using AutoMapper;
using Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dto;
using Services;

namespace CreditApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseAppController
{
    private readonly IAccountService _accountService;

    public AccountController(IMapper mapper , ILogger<AccountController> logger , IAccountService accountService)
    : base(mapper , logger )
    {
        _accountService = accountService;
    }


    [HttpPost]
    public async Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken = default)
    {
        var account = _mapper.Map<Account>(accountDto);
        var result = await _accountService.CreateAccountAsync(account, cancellationToken);
        return await base.CreatedResult(result);
    }

     
}

