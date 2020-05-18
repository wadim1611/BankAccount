using AutoMapper;
using BankAccount.Api.Contracts.V1.Responses;
using BankAccount.Core.Domain.Models;

namespace BankAccount.Api.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<Currency, CurrencyModel>();
            CreateMap<Account, AccountModel>();
        }
    }
}