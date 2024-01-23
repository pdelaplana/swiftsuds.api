using SwiftSuds.Domain.ValueObjects;

namespace SwiftSuds.Order.Api.Modules.Customers.V1.Endpoints;

public record CreateCustomerRequest(string Name, string Email, string Phone, Address Address);
