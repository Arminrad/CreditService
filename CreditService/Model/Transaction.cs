namespace CreditService.Model
{
    public class Transaction
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int EmployerAccountId { get; set; }
        public DateTime TransactionDate = DateTime.Now;
    }
}
