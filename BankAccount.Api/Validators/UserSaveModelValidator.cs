using BankAccount.Api.Contracts.V1.Requests;
using FluentValidation;

namespace BankAccount.Api.Validators
{
    public class UserSaveModelValidator : AbstractValidator<UserSaveModel>
    {
        public UserSaveModelValidator()
        {
            RuleFor(x => x.Name).Length(2, 50);
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
