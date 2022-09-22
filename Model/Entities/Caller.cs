using Model.Base.Implementations;

namespace Model.Entities
{
    public class Caller : BaseEntity<Guid>
    {
        public string CallerName { get; set; }
    }
}
