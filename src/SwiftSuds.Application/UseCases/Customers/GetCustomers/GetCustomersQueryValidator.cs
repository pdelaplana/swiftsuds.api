using FluentValidation;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomers;
internal class GetCustomersQueryValidator : AbstractValidator<GetCustomersQuery>
{
    public GetCustomersQueryValidator()
    {
        RuleFor(query => query.Offset).GreaterThanOrEqualTo(0);
        RuleFor(query=> query.Limit).GreaterThan(0);
    }
}
