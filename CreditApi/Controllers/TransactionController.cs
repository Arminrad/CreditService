using AutoMapper;
using Common.ActionResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Dto;
using Services;

namespace CreditApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {

        private readonly ILogger<TransactionController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly IMapper _mapper;

        public TransactionController(TransactionService transactionService, ILogger<TransactionController> logger, IMapper mapper)
        {
            this._logger = logger;
            this._transactionService = transactionService;
            this._mapper = mapper;
        }


        [HttpPost("[action]")]
        public async Task<ActionResponse> DepositAsync(TransactionDto transactionDto, CancellationToken cancellationToken)
        {

            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);


             var result =  await _transactionService.DepositAsync(accountTransaction, cancellationToken);
             return result;

        }

        [HttpPost("[action]")]
        public async Task<ActionResponse> ReturnAsync(TransactionDto transactionDto, CancellationToken cancellationToken)
        {

            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);


            var result = await _transactionService.ReturnAsync(accountTransaction, cancellationToken);
            return result;

        }


        [HttpPost("[action]")]
        public async Task<ActionResponse> WithdrawAsync(TransactionDto transactionDto, CancellationToken cancellationToken)
        {

            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);


            var result = await _transactionService.WithdrawAsync(accountTransaction, cancellationToken);
            return result;

        }

        [HttpPost("[action]")]
        public async Task<ActionResponse> BuyAsync(TransactionDto transactionDto, CancellationToken cancellationToken)
        {

            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);


            var result = await _transactionService.BuyAsync(accountTransaction, cancellationToken);
            return result;

        }
    }
}
