using AutoMapper;
using Model.Dto;
using Model.Entities;

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
