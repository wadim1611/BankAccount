using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UsersService(IUsersRepository usersRepository, IUnitOfWork unitOfWork)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<User> CreateAsync(User user)
        {
            await _usersRepository.CreateAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _usersRepository.GetByIdAsync(id);
            if (user == null) throw new ArgumentOutOfRangeException($"User with id {id} not found");
            _usersRepository.Remove(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _usersRepository.GetUsersAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _usersRepository.GetByIdAsync(id);
        }

        public async Task<User> UpdateAsync(int id, User user)
        {
            var userToUpdate = await _usersRepository.GetByIdAsync(id);
            if(userToUpdate == null) throw new ArgumentOutOfRangeException($"User with id {id} not found");

            user.Id = userToUpdate.Id;
            _usersRepository.Update(user);
            return await _usersRepository.GetByIdAsync(id);
        }
    }
}
