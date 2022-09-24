using Common.ActionResult;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Model.Entities.Enum;
using Repository.UnitOfWorks;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TransactionService> _logger;
        private readonly IAccountService _accountService;

        public TransactionService(IUnitOfWork unitOfWork, ILogger<TransactionService> logger, IAccountService accountService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _accountService = accountService;
        }

        public async Task<ActionResponse> BuyAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {
            accountTransaction.TransactionType = TransactionType.Buy;
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                await _unitOfWork.TransactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Success);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");
            }
        }

        public async Task<ActionResponse> WithdrawAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {
            accountTransaction.TransactionType = TransactionType.Withdraw;
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                await _unitOfWork.TransactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Success);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");
            }
        }

        public async Task<ActionResponse> ReturnAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {
            accountTransaction.TransactionType = TransactionType.Return;
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                await _unitOfWork.TransactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Success);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");
            }
        }

        public async Task<ActionResponse> DepositAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {
            accountTransaction.TransactionType = TransactionType.Deposit;
            var transaction = await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                await _unitOfWork.TransactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Success);
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");
            }
        }
    }
}
