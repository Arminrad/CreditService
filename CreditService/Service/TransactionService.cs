using CreditService.Model;

namespace CreditService.Service
{
    public class TransactionService : GenericService<Transaction, int>
    {
        public int Delete(Transaction t)
        {
            throw new NotImplementedException();
        }

        public List<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(Transaction t)
        {
            throw new NotImplementedException();
        }

        public int Update(Transaction t)
        {
            throw new NotImplementedException();
        }

        void GenericService<Transaction, int>.Delete(Transaction t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        Transaction GenericService<Transaction, int>.GetById(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        void GenericService<Transaction, int>.Insert(Transaction t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void GenericService<Transaction, int>.Update(Transaction t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
