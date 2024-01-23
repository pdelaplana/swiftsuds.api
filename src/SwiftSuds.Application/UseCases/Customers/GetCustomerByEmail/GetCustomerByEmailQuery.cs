using MediatR;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;

namespace SwiftSuds.Application.UseCases.Customers.GetCustomerByEmail;
public class GetCustomerByEmailQuery : IRequest<Result<Customer, DomainError>>
{
    public string Email { get; set; } = null!;
}
