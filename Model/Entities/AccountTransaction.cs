using Model.Base.Implementations;
using Model.Entities.Enum;

namespace Model.Entities
{
    public class AccountTransaction : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public TransactionType TransactionType { get; set; }
        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
