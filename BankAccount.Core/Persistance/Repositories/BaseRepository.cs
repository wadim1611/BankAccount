using BankAccount.Core.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount.Core.Persistance.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
