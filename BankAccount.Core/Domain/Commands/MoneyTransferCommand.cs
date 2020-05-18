using BankAccount.Core.Domain.Services.Interfaces;

namespace BankAccount.Core.Domain.Commands
{
    public class MoneyTransferCommand : CompositeBankAccountCommand
    {
        public MoneyTransferCommand(IAccountService accountService, int accountFrom, int accountTo, decimal amount, decimal exchangeRate = 1)
        {
            AddRange(new[]
            {
                new BankAccountCommand(accountService, accountFrom, BankAccountCommand.Action.Withdraw, amount),
                new BankAccountCommand(accountService, accountTo, BankAccountCommand.Action.Deposit, amount * exchangeRate),
            });
        }
    }
}
