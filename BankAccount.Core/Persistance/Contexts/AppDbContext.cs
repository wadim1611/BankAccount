using BankAccount.Core.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAccount.Core.Persistance.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
