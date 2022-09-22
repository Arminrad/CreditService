using Model.Base.Implementations;

namespace Model
{
    public class Caller : BaseEntity<Guid>
    {
        public string CallerName { get; set; }
    }
}
