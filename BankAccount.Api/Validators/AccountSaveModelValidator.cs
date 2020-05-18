using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class AccountSaveModelValidator : AbstractValidator<AccountSaveModel>
    {
        public AccountSaveModelValidator()
        {
            RuleFor(x => x.CurrencyId).GreaterThanOrEqualTo(0);
            RuleFor(x => x.UserId).GreaterThanOrEqualTo(0);
        }
    }
}
