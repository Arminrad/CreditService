namespace CreditService.Model
{
    public class TransactionRecords
    {
        private int id;
        private int userId;
        private decimal amount;
        private bool isDeposit;
        private DateTime transactionTime;

        public int Id { get { return id; } set { id = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public decimal Amount { get { return amount; } set { amount = value; } }
        public bool IsDeposit { get { return isDeposit; } set { isDeposit = value; } }
        public DateTime TransactionTime = DateTime.Now;
    }
}
