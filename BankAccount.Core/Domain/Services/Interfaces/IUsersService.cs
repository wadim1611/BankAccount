using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services.Interfaces
{
    public interface IUsersService
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(int id, User user);
        Task DeleteAsync(int id);
    }
}
