using FluentValidation;


namespace SwiftSuds.Application.UseCases.Businesses.GetBusinessById;
internal class GetBusinessByIdQueryValidator: AbstractValidator<GetBusinessByIdQuery>
{
    public GetBusinessByIdQueryValidator()
    {
        RuleFor(query => query.BusinessId).NotNull();
    }
}
