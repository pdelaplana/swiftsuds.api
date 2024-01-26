using FluentValidation;

namespace SwiftSuds.Application.UseCases.Registration.RegisterAccount;
internal class RegisterAccountCommandValidator: AbstractValidator<RegisterAccountCommand>
{
    public RegisterAccountCommandValidator()
    {
        RuleFor(command => command.Name).NotEmpty().MaximumLength(120);
        RuleFor(command => command.Email).EmailAddress();
        RuleFor(command=> command.Address.StreetAddress1).NotEmpty();
    }
}
