namespace CreditService.Service
{
    public interface GenericService<T1, T2>
    {
        T1 GetById(CancellationToken cancellationToken, T2 id);
        List<T1> GetAll();
        void Insert(T1 t, CancellationToken cancellationToken);
        void Update(T1 t, CancellationToken cancellationToken);
        void Delete(T1 t, CancellationToken cancellationToken);
    }
}
