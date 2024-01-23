using FluentValidation;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomers;
internal class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
{
    public GetCustomersQueryValidator()
    {
        RuleFor(model => model.Offset).GreaterThan(0);
        RuleFor(model => model.Limit).GreaterThan(0);
    }
}
