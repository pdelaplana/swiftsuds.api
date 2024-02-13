using FluentValidation;
using MediatR;
using SwiftSuds.Application.Abstractions.Repositories.ReadOnly;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Errors;


namespace SwiftSuds.Application.UseCases.Businesses.GetBusinesses;
public class GetBusinessesQueryHandler(
        IBusinessReadOnlyRepository businessReadOnlyRepository,
        IValidator<GetBusinessesQuery> validator)
    : IRequestHandler<GetBusinessesQuery, Result<ICollection<Business>, DomainError>>
{
    public async  Task<Result<ICollection<Business>, DomainError>> Handle(GetBusinessesQuery request, CancellationToken cancellationToken)
    {
        var (isValid, errors) = await validator.ValidateAndReturnErrorsAsync(request, cancellationToken);
        if (!isValid) return errors!;

        return (await businessReadOnlyRepository.GetBusinessesAsync(request.Offset, request.Limit)).ToList();
      
    }
}
