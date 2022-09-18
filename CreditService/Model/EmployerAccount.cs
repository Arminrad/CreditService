using CreditService.Model.Base;

namespace CreditService.Model
{
    public class EmployerAccount: BaseEntity
    {
        public decimal Balance { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }

    }
}
