using Common.ActionResult;
using Common.Clients;
using Model.Entities;

namespace Services
{
    public interface IAccountService
    {
        Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken);
        Task<ActionResponse> IncreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken);
        Task<ActionResponse> DecreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken);
        Task<ActionResponse> GetBalanceAsync(Account account, CancellationToken cancellationToken);
        Task<ActionResponse> IncreaseClubPointsAsync(int userId, int amount, CancellationToken cancellationToken);

        Task<ActionResponse> GetAccountsByCreditAsync(Decimal minimumBalance, int pageNumber, int pageSize, CancellationToken cancellationToken);
        Task<ActionResponse> GetAccountsByMemberShipType(MemberShipType type, int pageNumber, int pageSize, CancellationToken cancellationToken);

    }
}
