using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Models;

public record CustomerInfo(
    Guid CustomerId,
    string Name,
    string Email,
    string Phone,
    Address Address);
