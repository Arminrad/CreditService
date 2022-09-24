using Microsoft.EntityFrameworkCore;
using Model.Entities;

namespace Repository.Connection
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
        public virtual DbSet<AccountTransaction> Transactions { get; set; }
        public virtual DbSet<Caller> callers { get; set; }
    }
}
