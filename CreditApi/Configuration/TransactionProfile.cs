using AutoMapper;
using Model;
using Model.Dto;

namespace CreditApi.Configuration
{
    public class TransactionProfile: Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionDto, AccountTransaction>();
        }
    }
}
