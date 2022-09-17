namespace CreditService.Model
{
    public class TransactionRecords
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public decimal Amount { get;  set; }
        public bool IsDeposit { get; set; }
        public DateTime TransactionTime = DateTime.Now;
    }
}
