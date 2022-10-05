using AutoMapper;
using Common.Clients;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers.v1;


[ApiVersion("1")]
public class AccountController : BaseAppController
{
    protected readonly IAccountService _accountService;

    public AccountController(IMapper mapper, ILogger<AccountController> logger, IAccountService accountService)
    : base(mapper, logger)
    {
        _accountService = accountService;
    }

    /// <summary>
    /// creates a new account for the user
    /// </summary>
    /// <param name="accountDto">userId for new account</param>
    /// <param name="cancellationToken"></param>
    /// <returns>true if created, false if userId is duplicated</returns>
    [HttpPost]
    public virtual async Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken = default)
    {
        var account = _mapper.Map<Account>(accountDto);
        var result = await _accountService.CreateAccountAsync(account, cancellationToken);
        return base.CreatedResult(result);
    }

    /// <summary>
    /// get User's balance
    /// </summary>
    /// <param name="accountDto">User's id</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [HttpGet("[Action]")]
    public virtual async Task<ActionResult> GetAccountBalance([FromQuery] AccountDto accountDto, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(accountDto);
        var balance = await _accountService.GetBalanceAsync(account, cancellationToken);
        return CreatedResult(balance);
    }


}