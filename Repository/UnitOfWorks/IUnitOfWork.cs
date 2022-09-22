using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Repository.RepositoryInterface;

namespace Repository.UnitOfWorks
{
    public class IUnitOfWork
    {
        private DbContext _dbContext;
        public DatabaseFacade Database;
        public IAccountRepository AccountRepository;
        public ITransactionRepository TransactionRepository;
    }
}
