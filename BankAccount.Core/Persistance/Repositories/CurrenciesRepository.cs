using BankAccount.Core.Domain.Models;
using BankAccount.Core.Persistance.Contexts;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories
{
    public class CurrenciesRepository : BaseRepository, ICurrenciesRepository
    {
        public CurrenciesRepository(AppDbContext context) : base(context) { }
        public async Task<Currency> CreateAsync(Currency currency)
        {
            await _context.Currencies.AddAsync(currency);
            return currency;
        }

        public async Task<Currency> GetByIdAsync(int id)
        {
            return await _context.Currencies.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Currency>> GetAll()
        {
            return await _context.Currencies.AsNoTracking().ToListAsync();
        }

        public void Remove(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }

        public void Update(Currency currency)
        {
            _context.Currencies.Update(currency);
        }
    }
}
