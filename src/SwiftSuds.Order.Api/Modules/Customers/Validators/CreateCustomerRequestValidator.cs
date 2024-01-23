using FluentValidation;
using SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

namespace SwiftSuds.Order.Api.Modules.Customers.Validators;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(model => model.Name).NotEmpty().MaximumLength(120);
        RuleFor(model => model.Email).EmailAddress();
        RuleFor(model => model.Address.StreetAddress1).NotEmpty();
    }
}
