using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Services
{
    public interface ITransactionService
    {
        Task BuyAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task DepositAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task WithdrawAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
        Task ReturnAsync(AccountTransaction accountTransaction, CancellationToken cancellationToken);
    }
}
