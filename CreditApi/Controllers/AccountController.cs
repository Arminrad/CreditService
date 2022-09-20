using AutoMapper;
using Model.Dto;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dto;
using Services;

namespace CreditApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;

    public AccountController(IAccountService accountService, IMapper mapper)
    {
        _accountService = accountService;
        _mapper = mapper;
    }


    [HttpPost]
    public async Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<Account>(accountDto);
        var result = await _accountService.CreateAccountAsync(account, cancellationToken);
        if (result.IsSuccess)
        {
            return Ok(result);
        }
        else
        {
            return BadRequest(result);
        }
    }
}

