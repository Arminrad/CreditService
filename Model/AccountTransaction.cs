using Model;
using Model.Base;

namespace Model
{
    public class AccountTransaction : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;

    }


}
