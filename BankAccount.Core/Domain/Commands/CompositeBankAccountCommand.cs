using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Commands
{
    public abstract class CompositeBankAccountCommand : List<BankAccountCommand>, ICommand
    {
        public virtual async Task CallAsync()
        {
            foreach (var cmd in this) 
            {
                await cmd.CallAsync();
            }
        }

        public virtual async Task UndoAsync()
        {
            foreach(var cmd in ((IEnumerable <BankAccountCommand>)this).Reverse())
            {
                await cmd.UndoAsync();
            }
        }

        public override string ToString()
        {
            return string.Join(Environment.NewLine, this.Select(c => c.ToString()));
        }
    }
}
