using AutoMapper;
using Common.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Services;

namespace CreditApi.Controllers.v2
{
    [ApiVersion("2")]
    public class AccountController : v1.AccountController
    {
        public AccountController(IMapper mapper, ILogger<v1.AccountController> logger, IAccountService accountService)
        : base(mapper, logger, accountService)
        {

        }

        public override Task<ActionResult> CreateAccount(AccountDto accountDto, CancellationToken cancellationToken = default)
        {
            return base.CreateAccount(accountDto, cancellationToken);
        }

        public override Task<ActionResult> GetAccountBalance(AccountDto accountDto, CancellationToken cancellationToken)
        {
            return base.GetAccountBalance(accountDto, cancellationToken);
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
        public virtual async Task<ActionResult> GetAccountsByCredit([FromQuery] Decimal minimumBalance, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellationToken = default)
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
        public virtual async Task<ActionResult> GetAccountsByMemberShipType([FromQuery] MemberShipType type, [FromQuery] int pageSize = 10, [FromQuery] int pageNumber = 1, CancellationToken cancellation = default)
        {
            var results = await _accountService.GetAccountsByMemberShipType(type, pageNumber, pageSize, cancellation);
            return CreatedResult(results);
        }



    }
}
