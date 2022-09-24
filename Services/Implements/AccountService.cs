using Common.ActionResult;
using Common.CustomExceptions;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Repository.UnitOfWorks;

namespace Services
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUnitOfWork unitOfWork, ILogger<AccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken = default)
        {
            if (!await _unitOfWork.AccountRepository.TableNoTracking.AnyAsync(x => x.UserId == account.UserId))
            {
                await _unitOfWork.AccountRepository.AddAsync(account, cancellationToken);
                await _unitOfWork.SaveAsync(cancellationToken);
                return new ActionResponse(true, ActionResultStatusCode.Created);
            }

            return new ActionResponse(false, ActionResultStatusCode.Exist);
        }

        public async Task<ActionResponse> IncreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetByUserIdAsync(userId, cancellationToken);
            Assert.NotNull(account, nameof(Account));
            account.Balance += amount;
            return new ActionResponse(true, ActionResultStatusCode.Success);
        }

        public async Task<ActionResponse> DecreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetByUserIdAsync(userId, cancellationToken);
            Assert.NotNull(account, nameof(Account));
            if (account.Balance < amount)
            {
                throw new InsufficientBallanceException();
            }
            account.Balance -= amount;
            return new ActionResponse(true, ActionResultStatusCode.Success);
        }
    }
}
