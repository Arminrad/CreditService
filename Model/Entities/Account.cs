using Model.Base.Implementations;

namespace Model.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<AccountTransaction> Transactions { get; set; }
    }
}
