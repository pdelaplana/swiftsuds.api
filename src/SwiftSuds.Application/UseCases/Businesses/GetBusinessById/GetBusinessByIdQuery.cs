using MediatR;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Businesses.GetBusinessById;
public class GetBusinessByIdQuery : IRequest<Result<Business, DomainError>>
{
    public Guid BusinessId { get; set; }
}
