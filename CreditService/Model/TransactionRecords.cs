using CreditService.Model.BaseEntity;

namespace CreditService.Model
{
    public class TransactionRecords : IBaseEntity
    {
        public int UserId { get; set; }
        public decimal Amount { get; set; }
        public bool IsDeposit { get; set; }
        public DateTime TransactionTime = DateTime.Now;
    }
}
