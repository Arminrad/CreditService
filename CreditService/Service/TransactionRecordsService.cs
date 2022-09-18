using CreditService.Model;

namespace CreditService.Service
{
    public class TransactionRecordsService : GenericService<TransactionRecords, int>
    {
        public int Delete(TransactionRecords t)
        {
            throw new NotImplementedException();
        }

        public List<TransactionRecords> GetAll()
        {
            throw new NotImplementedException();
        }

        public TransactionRecords GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Insert(TransactionRecords t)
        {
            throw new NotImplementedException();
        }

        public int Update(TransactionRecords t)
        {
            throw new NotImplementedException();
        }

        void GenericService<TransactionRecords, int>.Delete(TransactionRecords t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        TransactionRecords GenericService<TransactionRecords, int>.GetById(CancellationToken cancellationToken, int id)
        {
            throw new NotImplementedException();
        }

        void GenericService<TransactionRecords, int>.Insert(TransactionRecords t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        void GenericService<TransactionRecords, int>.Update(TransactionRecords t, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
