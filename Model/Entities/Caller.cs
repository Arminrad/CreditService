using System.ComponentModel.DataAnnotations;
using Model.Base.Implementations;

namespace Model.Entities
{
    public class Caller : BaseEntity<Guid>
    {
        [MaxLength(100)]
        public string CallerName { get; set; }
    }
}
