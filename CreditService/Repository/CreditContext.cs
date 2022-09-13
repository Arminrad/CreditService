using CreditService.Model;
using System.Data.Entity;

namespace CreditService.Repository
{
    public class CreditContext : DbContext
    {
        public CreditContext() : base("CreditContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionRecords> TransactionRecords { get; set; }
    }
}
