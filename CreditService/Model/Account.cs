namespace CreditService.Model
{
    public class Account
    {
        private int id;
        private decimal balance;

        public int Id { get { return id; } set { id = value; } }
        public decimal Balance { get { return balance; } set { balance = value; } }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
