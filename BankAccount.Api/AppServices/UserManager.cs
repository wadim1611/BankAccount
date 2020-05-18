using AutoMapper;
using BankAccount.Api.AppServices.Interfaces;
using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices
{
    public class UserManager : IUserManager
    {
        private readonly IUsersService _usersService;
        private readonly IMapper _mapper;

        public UserManager(IUsersService usersService, IMapper mapper)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<UserModel> CreateUserAsync(UserSaveModel model)
        {
            var user = _mapper.Map<User>(model);
            var createdUser = await _usersService.CreateAsync(user);
            return _mapper.Map<UserModel>(createdUser);
        }

        public async Task DeleteUserAsync(int userId)
        {
            await _usersService.DeleteAsync(userId);
        }

        public async Task<IEnumerable<UserModel>> GetAllAsync()
        {
            var users = await _usersService.GetAllAsync();
            return _mapper.Map<IEnumerable<UserModel>>(users);
        }

        public async Task<UserModel> GetByIdAsync(int userId)
        {
            var user = await _usersService.GetByIdAsync(userId);
            return _mapper.Map<UserModel>(user);
        }

        public async Task UpdateUserAsync(int id, UserSaveModel model)
        {
            var user = _mapper.Map<User>(model);
            await _usersService.UpdateAsync(id, user);
        }
    }
}
