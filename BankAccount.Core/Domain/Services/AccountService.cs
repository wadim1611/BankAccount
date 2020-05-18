using BankAccount.Core.Domain.Commands;
using BankAccount.Core.Domain.Models;
using BankAccount.Core.Domain.Services.Interfaces;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountsRepository _accountsRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IAccountsRepository accountsRepository, IUnitOfWork unitOfWork)
        {
            _accountsRepository = accountsRepository ?? throw new ArgumentNullException(nameof(accountsRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _accountsRepository.GetAllAsync();
        }

        public async Task<Account> GetByIdAsunc(int id)
        {
            return await _accountsRepository.GetByIdAsync(id);

        }

        public async Task DeleteAsync(int id)
        {
            var account = await _accountsRepository.GetByIdAsync(id);
            if (account == null) throw new ArgumentOutOfRangeException($"Account with id: {id} not found");
            _accountsRepository.Remove(account);
        }

        public async Task<Account> CreateAccountAsync(int userId, int currencyId)
        {
            Account account = new Account
            {
                Balance = 0,
                CurrencyId = currencyId,
                OpenedDate = DateTime.UtcNow
            };
            var newAccount = await _accountsRepository.CreateAsync(account);
            await _unitOfWork.CompleteAsync();
            return newAccount;
        }

        public async Task<Account> DebitAccountAsync(int accountId, decimal amount)
        {
            var account = await _accountsRepository.GetByIdAsync(accountId);
            if (account == null) 
            {
                throw new ArgumentException($"Account with id: {accountId} not found"); 
            }

            account.Balance += amount;
            _accountsRepository.Update(account);
            await _unitOfWork.CompleteAsync();
            return await _accountsRepository.GetByIdAsync(accountId);
        }

        public async Task<Account> WithdrawAccountAsync(int accountId, decimal amount)
        {
            var account = await _accountsRepository.GetByIdAsync(accountId);
            if (account == null)
            {
                throw new ArgumentException($"Account with id: {accountId} not found");
            }

            account.Balance -= amount;
            _accountsRepository.Update(account);
            await _unitOfWork.CompleteAsync();
            return await _accountsRepository.GetByIdAsync(accountId);
        }

        public async Task ExecuteAsync(ICommand command)
        {
            var failed = false;
            try
            {
                await command.CallAsync();
            }
            catch(Exception ex)
            {
                // TODO: log exception
                failed = true;
            }

            if (failed)
            {
                try
                {
                    await command.UndoAsync();
                }
                catch (Exception ex)
                {
                    // TODO: log exception
                    throw new Exception($"Unable to undo command {command}", ex);
                }
            }
            
        }
    }
}
