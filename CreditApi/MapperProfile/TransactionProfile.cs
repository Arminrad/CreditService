using AutoMapper;
using Model.Dto;
using Model.Entities;

namespace CreditApi.MapperProfile
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionDto, AccountTransaction>();
        }
    }
}
