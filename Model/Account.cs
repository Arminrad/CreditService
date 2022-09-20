using Model;
using Model.Base;


namespace Model
{
    public class Account : BaseEntity
    {

        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public virtual ICollection<AccountTransaction> Transactions { get; set; }


    }
}
