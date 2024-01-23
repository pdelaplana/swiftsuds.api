using MediatR;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomers;
public class GetCustomersQuery : IRequest<Result<ICollection<Customer>, DomainError>>
{
    public int Offset { get; set; }
    public int Limit { get; set; }

}
