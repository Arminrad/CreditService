using Model.Base.Interfaces;

namespace Model.Base.Implementations
{
    public abstract class BaseEntity<TKey> : IBaseEntity
    {
        public TKey Id { get; set; }
    }

    public abstract class BaseEntity : BaseEntity<int>
    {
    }
}
