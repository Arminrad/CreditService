namespace Model
{
    public enum TransactionType: short
    {
        Deposit = 1,
        Withdraw = -1,
        Return = 2,
        Buy = -2
    }
}