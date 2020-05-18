using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class AccountWithdrawModelValidator : AbstractValidator<AccountWithdrawModel>
    {
        public AccountWithdrawModelValidator()
        {
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AccountId).GreaterThanOrEqualTo(0);
        }
    }
}
