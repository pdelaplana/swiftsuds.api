using MediatR;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomerById;
public class GetCustomerByIdQuery : IRequest<Result<Customer, DomainError>>
{
    public Guid Id { get; set; }
}
