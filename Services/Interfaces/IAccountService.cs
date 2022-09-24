using Common.ActionResult;
using Model.Entities;

namespace Services
{
    public interface IAccountService
    {
        Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken);
        Task<ActionResponse> IncreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken);
        Task<ActionResponse> DecreaseBalanceAsync(int userId, decimal amount, CancellationToken cancellationToken);
    }
}
