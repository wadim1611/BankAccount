using System.Threading.Tasks;

namespace BankAccount.Core.Persistance.Repositories.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
