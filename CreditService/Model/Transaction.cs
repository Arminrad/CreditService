using CreditService.Model.BaseEntity;

namespace CreditService.Model
{
    public class Transaction : IBaseEntity
    {
        public int CustomerId { get; set; }
        public int EmployerAccountId { get; set; }
        public DateTime TransactionDate = DateTime.Now;
    }
}
