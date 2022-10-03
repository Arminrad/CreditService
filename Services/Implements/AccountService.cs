using System.Linq.Expressions;
using Common.ActionResult;
using Common.Clients;
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

        public async Task<ActionResponse> GetBalanceAsync(Account account, CancellationToken cancellationToken)
        {
            if (await _unitOfWork.AccountRepository.TableNoTracking.AnyAsync(x => x.UserId == account.UserId))
            {
                var balance = await _unitOfWork.AccountRepository.GetBalanceAsync(account.UserId, cancellationToken);
                return new ActionResponse<Decimal>(true, ActionResultStatusCode.Fetched, balance);
            }

            return new ActionResponse(false, ActionResultStatusCode.InvalidUserId);
        }

        public async Task<ActionResponse> IncreaseClubPointsAsync(int userId, int amount, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.AccountRepository.GetByUserIdAsync(userId, cancellationToken);
            Assert.NotNull(account, nameof(Account));
            account.Club_Points += amount;
            return new ActionResponse(true, ActionResultStatusCode.Success);
        }

        public async Task<ActionResponse> GetAccountsByCreditAsync(Decimal minimumBalance, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var accounts = await _unitOfWork.AccountRepository.TableNoTracking
                                                                         .Where(x => minimumBalance <= x.Balance)
                                                                         .OrderBy(x=> x.Balance)
                                                                         .Skip(pageSize * (pageNumber - 1))
                                                                         .Take(pageSize)
                                                                         .Select(x => x.UserId)
                                                                         .ToListAsync(cancellationToken);

            if (accounts.Count() > 0)
                return new ActionResponse<object>(true, ActionResultStatusCode.Fetched, accounts);
            return new ActionResponse(false, ActionResultStatusCode.ListEmpty);
        }

        public async Task<ActionResponse> GetAccountsByMemberShipType(MemberShipType memberType, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var accounts =  await _unitOfWork.AccountRepository.TableNoTracking
                                                                    .Where(_typeOf(memberType))
                                                                    .OrderBy(x => x.Club_Points)
                                                                    .Skip(pageSize * (pageNumber -1))
                                                                    .Take(pageSize)
                                                                    .OrderBy(x=> x.Club_Points)
                                                                    .Select(x => x.UserId)
                                                                    .ToListAsync(cancellationToken);

            if (accounts.Any())
                return new ActionResponse<object>(true, ActionResultStatusCode.Fetched, accounts);
            return new ActionResponse(false, ActionResultStatusCode.ListEmpty);

        }


        private Expression<Func<Account, bool>> _typeOf(MemberShipType type)
        {
            switch (type)
            {
                case MemberShipType.Gold:
                    return x => x.Club_Points >= MemberShip.GoldBound;

                case MemberShipType.Silver:
                    return x => x.Club_Points < MemberShip.GoldBound && x.Club_Points >= MemberShip.SilverBound;

                case MemberShipType.Bronze:
                    return x => x.Club_Points < MemberShip.SilverBound;
            }

            throw new Exception("MemberShip type is invalid");
        }
    }
}
