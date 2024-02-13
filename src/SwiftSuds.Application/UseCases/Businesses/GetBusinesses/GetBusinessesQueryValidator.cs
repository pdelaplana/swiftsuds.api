using FluentValidation;

namespace SwiftSuds.Application.UseCases.Businesses.GetBusinesses;
internal class GetBusinessesQueryValidator: AbstractValidator<GetBusinessesQuery>
{
    public GetBusinessesQueryValidator()
    {
        RuleFor(query => query.Offset).GreaterThanOrEqualTo(0);
        RuleFor(query => query.Limit).GreaterThan(0);
    }
}
