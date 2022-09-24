using Common.ActionResult;
using Model.Entities;

namespace Services
{
    public interface ITransactionService
    {
        Task<ActionResponse> BuyAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task<ActionResponse> DepositAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task<ActionResponse> WithdrawAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task<ActionResponse> ReturnAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
    }
}
