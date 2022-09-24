using AutoMapper;
using Model.Dto;
using Model.Entities;

namespace CreditApi.MapperProfile
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto, Account>();
        }
    }
}
