using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditService.Model.ApiResults;
using Model;

namespace Services
{
    public interface IAccountService
    {
        Task<ActionResponse> CreateAccountAsync(Account account, CancellationToken cancellationToken);
    }
}
