using Model.Entities;
using Repository.Base.GenericRepositoryImplementation;
using Repository.Connection;
using Repository.RepositoryInterface;

namespace Repository.RepositoryImplementation
{
    public class CallerRepository: GenericRepository<Caller> , ICallerRepository
    {
        public CallerRepository(CreditContext dbContext) : base(dbContext)
        {

        }
    }
}
