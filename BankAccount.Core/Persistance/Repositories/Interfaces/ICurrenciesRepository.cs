using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories.Interfaces
{
    public interface ICurrenciesRepository
    {
        Task<IEnumerable<Currency>> GetAll();
        Task<Currency> GetByIdAsync(int id);
        Task<Currency> CreateAsync(Currency currency);
        void Update(Currency currency);
        void Remove(Currency currency);
    }
}
