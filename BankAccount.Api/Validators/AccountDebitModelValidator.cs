using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class AccountDebitModelValidator : AbstractValidator<AccountDebitModel>
    {
        public AccountDebitModelValidator()
        {
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AccountId).GreaterThanOrEqualTo(0);
        }
    }
}
