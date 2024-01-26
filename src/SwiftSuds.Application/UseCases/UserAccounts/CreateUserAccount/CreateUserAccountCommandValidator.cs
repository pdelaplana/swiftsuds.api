using FluentValidation;

namespace SwiftSuds.Application.UseCases.UserAccounts.CreateUserAccount;
internal class CreateUserAccountCommandValidator : AbstractValidator<CreateUserAccountCommand>
{
    public CreateUserAccountCommandValidator()
    {
        RuleFor(model => model.Email).EmailAddress();
        RuleFor(model => model.AccountType).IsInEnum();
    }
}
