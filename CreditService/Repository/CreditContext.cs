using CreditService.Model;
using Microsoft.EntityFrameworkCore;



namespace CreditService.Repository
{
    public class CreditContext : DbContext
    {
        // public CreditContext() : base("CreditContext")
        // {
        // }

        public CreditContext(DbContextOptions options)
            : base(options)
        {

        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<TransactionRecords> TransactionRecords { get; set; }
    }
}
