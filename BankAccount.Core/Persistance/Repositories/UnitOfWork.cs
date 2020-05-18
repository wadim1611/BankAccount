using BankAccount.Core.Persistance.Contexts;
using BankAccount.Core.Persistance.Repositories.Interfaces;
using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
