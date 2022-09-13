namespace CreditService.Repository
{
    public interface GenericRepository<T1, T2>
    {
        T1 GetById(T2 id);
        List<T1> GetAll();
        T2 Insert(T1 t);
        T2 Update(T1 t);
        T2 Delete(T1 t);
    }
}
