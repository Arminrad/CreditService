using CreditService.Model.BaseEntity;

namespace CreditService.Model
{
    public class Account : IBaseEntity
    {
        public decimal Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
