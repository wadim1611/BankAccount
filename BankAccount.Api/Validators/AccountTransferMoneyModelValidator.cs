using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class AccountTransferMoneyModelValidator : AbstractValidator<AccountTransferMoneyModel>
    {
        public AccountTransferMoneyModelValidator()
        {
            RuleFor(x => x.AccountIdFrom).GreaterThanOrEqualTo(0);
            RuleFor(x => x.AccountIdTo).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
        }
    }
}
