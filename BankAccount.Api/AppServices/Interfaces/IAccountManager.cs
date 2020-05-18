using BankAccount.Api.Contracts.V1.Requests;
using BankAccount.Api.Contracts.V1.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BankAccount.Api.AppServices.Interfaces
{
    public interface IAccountManager
    {
        Task<IEnumerable<AccountModel>> GetAll();
        Task<AccountModel> GetById(int id);
        Task<AccountModel> CreateAccount(AccountSaveModel model);
        Task DeleteAccount(int id);

        Task DebitAccount(AccountDebitModel model);
        Task WithdrawAccount(AccountWithdrawModel model);
        Task TransferMoney(AccountTransferMoneyModel model);
    }
}
