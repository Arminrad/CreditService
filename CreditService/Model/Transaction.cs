namespace CreditService.Model
{
    public class Transaction
    {
        private int id;
        private int customerId;
        private int employerAccountId;
        private DateTime transactionDate;

        public int Id { get { return id; } set { id = value; } }
        public int CustomerId { get { return customerId; } set { customerId = value; } }
        public int EmployerAccountId { get { return employerAccountId; } set { employerAccountId = value; } }
        public DateTime TransactionDate = DateTime.Now;
    }
}
