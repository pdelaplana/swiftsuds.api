using MediatR;
using SwiftSuds.Domain.Entities.Businesses;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Businesses.GetBusinesses;
public class GetBusinessesQuery : IRequest<Result<ICollection<Business>, DomainError>>
{
    public int Offset { get; set; }
    public int Limit { get; set; }
}
