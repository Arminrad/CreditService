using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Common.Clients;
using Common.Utilities;
using Microsoft.EntityFrameworkCore;
using Model.Base.Implementations;

namespace Model.Entities
{
    [Index(nameof(Balance))]
    public class Account : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        public decimal Balance { get; set; }

        public int Club_Points { get; set; }

        [NotMapped] public MemberShipType MemberType => MemberShip.GetType(Club_Points);

        public virtual ICollection<AccountTransaction> Transactions { get; set; }
    }
}
