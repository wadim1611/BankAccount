using BankAccount.Core.Domain.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace BankAccount.Core.Domain.Commands
{
    public class BankAccountCommand : ICommand
    {
        private readonly IAccountService _accountService;

        public enum Action
        {
            Deposit,
            Withdraw
        }

        private bool _succeeded = false;
        private int _accountId;
        private Action _action;
        private decimal _amount;

        public BankAccountCommand(IAccountService accountService, int accountId, Action action, decimal amount)
        {
            _accountService = accountService ?? throw new ArgumentNullException(nameof(accountService));
            _accountId = accountId;
            _action = action;
            _amount = amount;
        }

        public async Task CallAsync()
        {
            switch (_action)
            {
                case Action.Deposit:
                    {
                        await _accountService.DebitAccountAsync(_accountId, _amount);
                        break;
                    }
                case Action.Withdraw:
                    {
                        await _accountService.WithdrawAccountAsync(_accountId, _amount);
                        break;
                    }
                default: 
                    {
                        throw new ArgumentOutOfRangeException(nameof(_action)); 
                    }
            }

            _succeeded = true;
        }

        public async Task UndoAsync()
        {
            if (!_succeeded) return;
            switch (_action)
            {
                case Action.Deposit:
                    {
                        await _accountService.WithdrawAccountAsync(_accountId, _amount);
                        break;
                    }
                case Action.Withdraw:
                    {
                        await _accountService.DebitAccountAsync(_accountId, _amount);
                        break;
                    }
                default:
                    {
                        throw new ArgumentOutOfRangeException(nameof(_action));
                    }
            }
        }

        public override string ToString()
        {
            return $"{this._action} command. Amount: {_amount}. Account: {_accountId}";
        }
    }
}
