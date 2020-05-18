using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services.Interfaces
{
    public interface ICurrencyService
    {
        Task<IEnumerable<Currency>> GetAllAsync();
        Task<Currency> GetByIdAsunc(int id);
        Task<Currency> CreateAsync(Currency currency);
        Task UpdateAsync(int id, Currency currency);
        Task DeleteAsync(int id);
    }
}
