using AutoMapper;
using Common.Clients;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers.v1;


//[ApiVersion("1")]
public class AccountController : BaseAppController
{
    private readonly IAccountService _accountService;

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
    public async Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken = default)
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
    public async Task<ActionResult> GetAccountBalance([FromQuery] AccountDto accountDto, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(accountDto);
        var balance = await _accountService.GetBalanceAsync(account, cancellationToken);
        return CreatedResult(balance);
    }

    /// <summary>
    /// get users that have minimum balance at least
    /// </summary>
    /// <param name="minimumBalance"></param>
    /// <param name="pageSize">page's length</param>
    /// <param name="pageNumber">page number</param>
    /// <param name="cancellationToken"></param>
    /// <returns>list of userIds</returns>
    [HttpGet("[Action]")]
    public async Task<ActionResult> GetAccountsByCredit([FromQuery] Decimal minimumBalance, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellationToken = default)
    {
        var accounts = await _accountService.GetAccountsByCreditAsync(minimumBalance, pageNumber, pageSize, cancellationToken);
        return CreatedResult(accounts);
    }

    /// <summary>
    /// get all users with requested membership type
    /// </summary>
    /// <param name="type">gold:1 silver:2 bronze::3</param>
    /// <param name="pageSize">page's length</param>
    /// <param name="pageNumber">page number</param>
    /// <param name="cancellationToken"></param>
    /// <returns>list of userIds</returns>
    [HttpGet("[Action]")]
    public async Task<ActionResult> GetAccountsByMemberShipType([FromQuery] MemberShipType type, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellation = default)
    {
        var results = await _accountService.GetAccountsByMemberShipType(type, pageNumber, pageSize, cancellation);
        return CreatedResult(results);
    }
}