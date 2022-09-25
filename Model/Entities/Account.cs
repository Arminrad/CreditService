using System.ComponentModel.DataAnnotations.Schema;
using Common.Clients;
using Common.Utilities;
using Model.Base.Implementations;

namespace Model.Entities
{
    public class Account : BaseEntity
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }
        public int Club_Points { get; set; }
        [NotMapped] public MemberShipType MemberType => MemberShip.GetType(Club_Points);
        public virtual ICollection<AccountTransaction> Transactions { get; set; }
    }
}
