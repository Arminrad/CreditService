using CreditService.Repository.RepositoryImplementation;
using Model;
using Repository;
using Repository.Connection;

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

        public async Task BuyAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Buy;
            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.AccountId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await _creditContext.Database.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await _creditContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }

        public async Task WithdrawAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Withdraw;
            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.DecreaseBalanceAsync(accountTransaction.AccountId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await _creditContext.Database.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await _creditContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }

        public async Task ReturnAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Return;
            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.AccountId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await _creditContext.Database.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await _creditContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }

        public async Task DepositAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken)
        {

            accountTransaction.TransactionType = TransactionType.Deposit;
            try
            {
                await _transactionRepository.AddAsync(accountTransaction, cancellationToken);
                await _accountService.IncreaseBalanceAsync(accountTransaction.AccountId, accountTransaction.Amount, cancellationToken);
                await _creditContext.SaveChangesAsync(cancellationToken);
                await _creditContext.Database.CommitTransactionAsync(cancellationToken);
            }
            catch (Exception e)
            {
                await _creditContext.Database.RollbackTransactionAsync(cancellationToken);
            }
        }
    }

}
