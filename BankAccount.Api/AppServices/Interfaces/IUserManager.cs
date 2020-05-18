using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices.Interfaces
{
    public interface IUserManager
    {
        Task<IEnumerable<UserModel>> GetAllAsync();
        Task<UserModel> GetByIdAsync(int userId);
        Task<UserModel> CreateUserAsync(UserSaveModel model);
        Task DeleteUserAsync(int userId);
        Task UpdateUserAsync(int id, UserSaveModel model);
    }
}
