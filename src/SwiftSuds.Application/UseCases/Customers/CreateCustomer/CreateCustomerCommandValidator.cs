using FluentValidation;

namespace SwiftSuds.Application.UseCases.Customers.CreateCustomer;
internal class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(model => model.Name).NotEmpty().MaximumLength(120);
        RuleFor(model => model.Email).EmailAddress();
        RuleFor(model => model.Address.StreetAddress1).NotEmpty();
    }
}
