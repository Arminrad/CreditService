using CreditService.Model.Base;

namespace CreditService.Model
{
    public class Transaction : BaseEntity
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }

    }


}
