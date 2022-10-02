using AutoMapper;
using Common.ActionResult;
using CreditApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers.v1
{
    
    public class TransactionController : BaseAppController
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger, IMapper mapper)
        :base(mapper, logger)
        {
            this._transactionService = transactionService;
        }


        /// <summary>
        /// charge the wallet 
        /// </summary>
        /// <param name="callerId">caller's special guid id</param>
        /// <param name="transactionDto">User's id and transaction ammount</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResult> DepositAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.DepositAsync(accountTransaction, cancellationToken);
            return CreatedResult(result);
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
        public async Task<ActionResult> ReturnAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
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
        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResult> WithdrawAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.WithdrawAsync(accountTransaction, cancellationToken);
            return CreatedResult(result);
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
        public async Task<ActionResult> BuyAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.BuyAsync(accountTransaction, cancellationToken);
            return CreatedResult(result);
        }
    }
}
