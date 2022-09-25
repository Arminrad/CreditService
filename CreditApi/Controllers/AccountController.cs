using AutoMapper;
using Common.Clients;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : BaseAppController
{
    private readonly IAccountService _accountService;

    public AccountController(IMapper mapper, ILogger<AccountController> logger, IAccountService accountService)
    : base(mapper, logger)
    {
        _accountService = accountService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken = default)
    {
        var account = _mapper.Map<Account>(accountDto);
        var result = await _accountService.CreateAccountAsync(account, cancellationToken);
        return base.CreatedResult(result);
    }

    [HttpGet("[Action]")]
    public async Task<ActionResult> GetAccountBalance([FromQuery] AccountDto accountDto, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(accountDto);
        var balance = await _accountService.GetBalanceAsync(account, cancellationToken);
        return CreatedResult(balance);
    }

    [HttpGet("[Action]")]
    public async Task<ActionResult> GetAccountsByCredit([FromQuery] Decimal minimumBalance, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellationToken = default)
    {
        var accounts = await _accountService.GetAccountsByCreditAsync(minimumBalance, pageNumber, pageSize, cancellationToken);
        return CreatedResult(accounts);
    }

    [HttpGet("[Action]")]
    public async Task<ActionResult> GetAccountsByMemberShipType([FromQuery] MemberShipType type, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellation = default)
    {
        var results = await _accountService.GetAccountsByMemberShipType(type, pageNumber, pageSize, cancellation);
        return CreatedResult(results);
    }
}