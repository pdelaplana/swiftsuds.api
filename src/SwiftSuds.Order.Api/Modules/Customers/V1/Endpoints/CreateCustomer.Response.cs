using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public record CreateCustomerResponse(
    Guid CustomerId,
    string Name,
    string Email,
    string Phone,
    Address Address = null!);
