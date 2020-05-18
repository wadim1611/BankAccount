using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class CurrencySaveModelValidator : AbstractValidator<CurrencySaveModel>
    {
        public CurrencySaveModelValidator()
        {
            RuleFor(x => x.Code).Length(1, 3);
        }
    }
}
