using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Repository.RepositoryInterface;

namespace Repository.UnitOfWorks
{
    public partial class UnitOfWork: IUnitOfWork
    {
        public UnitOfWork(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            this.AccountRepository = accountRepository;
            this.TransactionRepository = transactionRepository;
             
        }
    }
}
