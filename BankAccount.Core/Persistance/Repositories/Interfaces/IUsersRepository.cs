using BankAccount.Core.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task<User> CreateAsync(User user);
        void Update(User user);
        void Remove(User user);
    }
}
