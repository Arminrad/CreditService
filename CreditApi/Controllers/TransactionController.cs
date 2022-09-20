using AutoMapper;
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


        [HttpPut]
        public async Task<ActionResult> DepositAsync(TransactionDto transactionDto, CancellationToken cancellationToken)
        {

            var accountTransaction = _mapper.Map<AccountTransaction>(transactionDto);
            await _transactionService.DepositAsync(accountTransaction, cancellationToken);
            return Ok();

        }
    }
}
