using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories.Interfaces
{
    public interface IAccountsRepository
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsync(int id);
        Task<Account> CreateAsync(Account account);
        void Update(Account account);
        void Remove(Account account);
    }
}
