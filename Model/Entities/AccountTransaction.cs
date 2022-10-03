using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using Model.Base.Implementations;
using Model.Entities.Enum;

namespace Model.Entities
{
    
    public class AccountTransaction : BaseEntity
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public TransactionType TransactionType { get; set; }

        public DateTime DateTime { get; set; } = DateTime.Now;
    }
}
