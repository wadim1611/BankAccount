using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Commands
{
    public interface ICommand
    {
        Task CallAsync();
        Task UndoAsync();
    }
}
