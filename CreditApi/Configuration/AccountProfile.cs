using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Model.Dto
{
    internal class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto, Account>();
        }
    }
}
