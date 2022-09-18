using Model;
using Model.Base;

namespace Model
{
    public class Transaction : BaseEntity
    {
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DateTime { get; set; }

    }


}
