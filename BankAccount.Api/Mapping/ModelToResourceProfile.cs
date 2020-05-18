using AutoMapper;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Core.Domain.Models;

namespace BankAccount.Api.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<UserSaveModel, User>();
            CreateMap<AccountSaveModel, Account>();
            CreateMap<CurrencySaveModel, Currency>();
        }
    }
}
