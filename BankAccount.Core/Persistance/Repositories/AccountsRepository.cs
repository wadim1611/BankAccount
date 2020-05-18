using BankAccount.Core.Domain.Models;
using BankAccount.Core.Persistance.Contexts;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories
{
    public class AccountsRepository : BaseRepository, IAccountsRepository
    {
        public AccountsRepository(AppDbContext context) : base(context) { }

        public async Task<Account> CreateAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            return account;
        }

        public async Task<IEnumerable<Account>> GetAllAsync()
        {
            return await _context.Accounts.AsNoTracking().ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int id)
        {
            return await _context.Accounts.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }

        public void Remove(Account account)
        {
            _context.Accounts.Remove(account);
        }

        public void Update(Account account)
        {
            _context.Accounts.Update(account);
        }
    }
}
