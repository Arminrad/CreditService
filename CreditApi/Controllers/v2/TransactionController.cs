using AutoMapper;
using CreditApi.Filters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers.v2
{
    [ApiVersion("2")]
    public class TransactionController : v1.TransactionController
    {
        public TransactionController(ITransactionService transactionService, ILogger<v1.TransactionController> logger, IMapper mapper)
        :base(transactionService, logger, mapper)
        {
            
        }

        /// <summary>
        /// charge the wallet 
        /// </summary>
        /// <param name="callerId">caller's special guid id</param>
        /// <param name="transactionDto">User's id and transaction ammount</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult> DepositAsync(Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            return base.DepositAsync(callerId, transactionDto, cancellationToken);
        }


        /// <summary>
        /// charge the wallet in case of rejecting products
        /// </summary>
        /// <param name="callerId">caller's special guid id</param>
        /// <param name="transactionDto">User's id and transaction amount</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public virtual async Task<ActionResult> ReturnAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.ReturnAsync(accountTransaction, cancellationToken);
            return base.CreatedResult(result);
        }


        /// <summary>
        /// discharge the wallet
        /// </summary>
        /// <param name="callerId">caller's special guid id</param>
        /// <param name="transactionDto">User's id and transaction amount</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<ActionResult> WithdrawAsync(Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            return base.WithdrawAsync(callerId, transactionDto, cancellationToken);
        }


        /// <summary>
        /// discharge the wallet in case of buying products
        /// </summary>
        /// <param name="callerId">caller's special guid id</param>
        /// <param name="transactionDto">User's id and transaction amount</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public virtual async Task<ActionResult> BuyAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.BuyAsync(accountTransaction, cancellationToken);
            return CreatedResult(result);
        }


    }
}
