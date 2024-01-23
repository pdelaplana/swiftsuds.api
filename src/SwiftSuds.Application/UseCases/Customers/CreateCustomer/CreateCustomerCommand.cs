using MediatR;
using SwiftSuds.Domain.Entities.Customers;
using SwiftSuds.Domain.Errors;
using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Application.UseCases.Customers.CreateCustomer;
public class CreateCustomerCommand : IRequest<Result<Customer, DomainError>>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public Address Address { get; set; } = null!;
}
