using AutoMapper;
using Common.ActionResult;
using CreditApi.Filters;
using Microsoft.AspNetCore.Mvc;
using Model.Dto;
using Model.Entities;
using Services;

namespace CreditApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class TransactionController : ControllerBase
    {
        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(ITransactionService transactionService, ILogger<TransactionController> logger, IMapper mapper)
        {
            this._logger = logger;
            this._transactionService = transactionService;
            this._mapper = mapper;
        }

        [HttpPost("[action]")]
        [MapToApiVersion("1.1")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResponse> DepositAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.DepositAsync(accountTransaction, cancellationToken);
            return result;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResponse> ReturnAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.ReturnAsync(accountTransaction, cancellationToken);
            return result;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResponse> WithdrawAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.WithdrawAsync(accountTransaction, cancellationToken);
            return result;
        }

        [HttpPost("[action]")]
        [ServiceFilter(typeof(CallerIdAuthorization))]
        public async Task<ActionResponse> BuyAsync([FromHeader] Guid callerId, TransactionDto transactionDto, CancellationToken cancellationToken)
        {
            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            var result = await _transactionService.BuyAsync(accountTransaction, cancellationToken);
            return result;
        }
    }
}
