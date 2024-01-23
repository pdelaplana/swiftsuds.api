using FluentValidation;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomerByEmail;
internal class GetCustomerByEmailQueryValidator: AbstractValidator<GetCustomerByEmailQuery>
{
    public GetCustomerByEmailQueryValidator()
    {
        RuleFor(model => model.Email).EmailAddress();
    }
}
