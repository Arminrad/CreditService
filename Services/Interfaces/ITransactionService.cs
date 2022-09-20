using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.ActionResult;
using Model;

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
