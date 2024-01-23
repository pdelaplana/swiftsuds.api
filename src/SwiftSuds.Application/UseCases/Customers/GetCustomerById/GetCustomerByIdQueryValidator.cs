using FluentValidation;


namespace SwiftSuds.Application.UseCases.Customers.GetCustomerById;
internal class GetCustomerByIdQueryValidator : AbstractValidator<GetCustomerByIdQuery>
{
    public GetCustomerByIdQueryValidator()
    {
        RuleFor(model => model.Id).NotEmpty();
    }
}
