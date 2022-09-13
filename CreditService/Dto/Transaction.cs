namespace CreditService.Dto
{
    public class Transaction
    {
        private int id;
        private int userId;
        private decimal amount;
        private bool isDeposit = true;

        public int Id { get { return id; } set { id = value; } }
        public int UserId { get { return userId; } set { userId = value; } }
        public decimal Amount { get { return amount; } set { amount = value; } }
        public bool IsDeposit { get { return isDeposit; } set { isDeposit = value; } }

    }
}
