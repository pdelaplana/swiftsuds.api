using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Businesses.GetBusinessById;
internal class GetBusinessByIdQueryHandler(
        IBusinessReadOnlyRepository businessReadOnlyRepository,
        IValidator<GetBusinessByIdQuery> validator)
    : IRequestHandler<GetBusinessByIdQuery, Result<Business, DomainError>>
{
    public async Task<Result<Business, DomainError>> Handle(GetBusinessByIdQuery request, CancellationToken cancellationToken)
    {
        var (isValid, errors) = await validator.ValidateAndReturnErrorsAsync(request, cancellationToken);
        if (!isValid) return errors!;

        var business = await businessReadOnlyRepository.GetBusinessByIdAsync(
            new BusinessId(request.BusinessId), 
            [b => b.BusinessServices]);
        return business == null ? new BusinessNotFound() : business;

    }
}
