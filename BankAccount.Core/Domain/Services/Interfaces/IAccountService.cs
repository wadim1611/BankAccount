using BankAccount.Core.Domain.Commands;
using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services.Interfaces
{
    public interface IAccountService
    {
        Task<IEnumerable<Account>> GetAllAsync();
        Task<Account> GetByIdAsunc(int id);
        Task DeleteAsync(int id);

        Task<Account> CreateAccountAsync(int userId, int currencyId);
        Task<Account> DebitAccountAsync(int accountId, decimal amount);
        Task<Account> WithdrawAccountAsync(int accountId, decimal amount);
        Task ExecuteAsync(ICommand command);
    }
}
