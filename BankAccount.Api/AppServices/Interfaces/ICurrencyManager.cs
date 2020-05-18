using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices.Interfaces
{
    public interface ICurrencyManager
    {
        Task<IEnumerable<CurrencyModel>> GetAllAsync();
        Task<CurrencyModel> GetByIdAsync(int id);
        Task<CurrencyModel> CreateAsync(CurrencySaveModel model);
        Task DeleteAsync(int id);
        Task UpdateAsync(int id, CurrencySaveModel model);
    }
}
