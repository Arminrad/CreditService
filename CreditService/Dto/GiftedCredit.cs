namespace CreditService.Dto
{
    public class GiftedCredit
    {
        private int id;
        private int donorId;
        private int receiverId;
        private decimal amount;

        public int Id { get { return id; } set { id = value; } }
        public int DonorId { get { return donorId; } set { donorId = value; } }
        public int ReceiverId { get { return receiverId; } set { receiverId = value; }}
        public decimal Amount { get { return amount; } set { amount = value; } }
    }
}
