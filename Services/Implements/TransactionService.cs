using Common.ActionResult;
using Common.CustomExceptions;
using Repository.RepositoryImplementation;
using Model.Entities;
using Model.Entities.Enum;
using Repository.Connection;
using Repository.RepositoryInterface;

namespace Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly CreditContext _creditContext;
        private readonly IAccountService _accountService;

        public TransactionService(ITransactionRepository transactionRepository, CreditContext creditContext, IAccountService accountService)
        {
            _transactionRepository = transactionRepository;
            _creditContext = creditContext;
            _accountService = accountService;
        }

        public async Task<ActionResponse> BuyAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Buy;
            var transaction = await _creditContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount,
                    cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new ActionResponse(true, ActionResultStatusCode.Success);

            }
            catch (ArgumentNullException)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.InvalidUserId);
            }
            catch (InsufficientBallanceException)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.Insufficient);
            }
            catch (Exception )
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");

            }
        }

        public async Task<ActionResponse> WithdrawAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Withdraw;
            var transaction = await _creditContext.Database.BeginTransactionAsync(cancellationToken);

            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new ActionResponse(true, ActionResultStatusCode.Success);

            }
            catch (ArgumentNullException )
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.InvalidUserId);
            }
            catch (InsufficientBallanceException)
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.Insufficient);
            }
            catch (Exception )
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");

            }
        }

        public async Task<ActionResponse> ReturnAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Return;
            var transaction = await _creditContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new ActionResponse(true, ActionResultStatusCode.Success);

            }
            catch (ArgumentNullException )
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.InvalidUserId);
            }
            catch (Exception )
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");

            }
        }

        public async Task<ActionResponse> DepositAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Deposit;
            var transaction =await _creditContext.Database.BeginTransactionAsync(cancellationToken);
            try
            {

                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.UserId, accountTransaction.Amount,
                    cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await transaction.CommitAsync(cancellationToken);

                return new ActionResponse(true, ActionResultStatusCode.Success);
            }
            catch (ArgumentNullException )
            {
                await transaction.RollbackAsync(cancellationToken);
                return new ActionResponse(false, ActionResultStatusCode.InvalidUserId);
            }
            catch (Exception )
            {
                await transaction.RollbackAsync(cancellationToken);
                throw new Exception("Internal Program Error");

            }
        }
    }

}
